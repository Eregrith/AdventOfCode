using AdventOfCode2019.Intcode.Events;
using AdventOfCode2019.Intcode.Opcodes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode2019.Intcode
{
    public class IntcodeDecompiler
    {
        private Dictionary<long, Opcode> Opcodes = new Dictionary<long, Opcode>
        {
            [1] = new Add(),
            [2] = new Multiply(),
            [3] = new WriteInput(),
            [4] = new WriteOutput(),
            [5] = new JumpIfTrue(),
            [6] = new JumpIfFalse(),
            [7] = new LessThan(),
            [8] = new Equals(),
            [9] = new OffsetRelativeBase(),
            [99] = new Finish()
        };

        public List<string> Decompile(long[] data)
        {
            List<string> decompiled = new List<string>();
            IntcodeContext context = new IntcodeContext(data, IntcodeMode.None, "decompiled");
            while (context.InstructionPointer < data.Length)
            {
                if (Opcodes.ContainsKey(context.CurrentOpcode))
                {
                    Opcode opcode = Opcodes[context.CurrentOpcode];
                    decompiled.Add(opcode.Describe(context));
                    context.InstructionPointer += opcode.Params + 1;
                }
                else
                {
                    decompiled.Add($"{{ {context.Id} }} {context.InstructionPointer:0000}: Raw data [{context.Data[context.InstructionPointer]}]");
                    context.InstructionPointer++;
                }
            }
            return decompiled;
        }

        public List<string> Labelize(long[] data)
        {
            List<IntcodeEvent> events = GenerateEventsBasedOnData(data);
            LabelizeEvents(events);
            return Textualize(events);
        }

        private List<IntcodeEvent> GenerateEventsBasedOnData(long[] data)
        {
            List<IntcodeEvent> events = new List<IntcodeEvent>();
            IntcodeContext context = new IntcodeContext(data, IntcodeMode.None, "decompiled");
            while (context.InstructionPointer < data.Length)
            {
                if (Opcodes.ContainsKey(context.CurrentOpcode))
                {
                    Opcode opcode = Opcodes[context.CurrentOpcode];
                    events.Add(opcode.ToEvent(context));
                    context.InstructionPointer += opcode.Params + 1;
                }
                else
                {
                    events.Add(new DataEvent(context.InstructionPointer, context.Data[context.InstructionPointer]));
                    context.InstructionPointer++;
                }
            }

            return events;
        }

        public static void LabelizeEvents(List<IntcodeEvent> events)
        {
            List<IntcodeEvent> jumpEvents = events.Where(e => e is JumpIfFalseEvent || e is JumpIfTrueEvent).ToList();
            List<EventParam> paramsTargettingAPosition = events.Except(jumpEvents).SelectMany(e => e.Params).Where(p => p.Mode != ParamMode.Immediate).ToList();
            paramsTargettingAPosition.AddRange(jumpEvents.SelectMany(p => p.Params));
            LabelStraightPos(events, jumpEvents, paramsTargettingAPosition);
            LabelInBetweenPos(events, jumpEvents, paramsTargettingAPosition);
        }

        private static void LabelInBetweenPos(List<IntcodeEvent> events, List<IntcodeEvent> jumpEvents, List<EventParam> paramsTargettingAPosition)
        {
            List<long> inBetweenPosition = paramsTargettingAPosition.Where(p => events.All(x => x.Address != p.Value)).Select(p => p.Value).Distinct().ToList();
            foreach (long targetedPos in inBetweenPosition.OrderBy(p => p))
            {
                foreach (EventParam targetingParam in paramsTargettingAPosition.Where(p => p.Value == targetedPos))
                {
                    if ((jumpEvents.Any(e => e.Params[1] == targetingParam))
                        && targetingParam.Mode == ParamMode.Position)
                        targetingParam.Label = "@[" + targetedPos + "]";
                    else
                        targetingParam.Label = "[" + targetedPos + "]";
                }
            }
        }

        private static void LabelStraightPos(List<IntcodeEvent> events, List<IntcodeEvent> jumpEvents, List<EventParam> paramsTargettingAPosition)
        {
            List<long> straightPositionsUsed = paramsTargettingAPosition.Where(p => events.Any(x => x.Address == p.Value)).Select(p => p.Value).Distinct().ToList();
            int posId = 0;
            foreach (long targetedPos in straightPositionsUsed.OrderBy(p => p))
            {
                foreach (EventParam targetingParam in paramsTargettingAPosition.Where(p => p.Value == targetedPos))
                {
                    if ((jumpEvents.Any(e => e.Params[1] == targetingParam))
                        && targetingParam.Mode == ParamMode.Position)
                        targetingParam.Label = "@pos_" + posId;
                    else
                        targetingParam.Label = "pos_" + posId;
                }
                events.First(e => e.Address == targetedPos).Label = "pos_" + posId;
                posId++;
            }
        }

        public static List<string> Textualize(List<IntcodeEvent> events)
        {
            List<string> text = new List<string>();
            foreach (IntcodeEvent e in events)
            {
                string currentText = String.Format("{0:0000}", e.Address) + " ";
                if (!String.IsNullOrEmpty(e.Label))
                {
                    if (e != events.First())
                        text.Add("");
                    currentText += e.Label + ": ";
                }
                else
                {
                    currentText += "       ";
                }
                currentText += e.ToString();
                text.Add(currentText);
            }

            return text;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2020.Opcode
{
    public class OpcodeInstruction
    {
        public bool AlreadyExecuted { get; set; } = false;
        public Action<OpcodeMachine> Action { get; private set; }
        public Action<OpcodeMachine> FlipAction { get; private set; }
        public Action<OpcodeMachine> Undo { get; private set; }
        public Action<OpcodeMachine> UndoFlip { get; private set; }
        private int Argument { get; set; }
        private string LineOrigin { get; set; }

        public static OpcodeInstruction FromLine(string line)
        {
            OpcodeInstruction op = new OpcodeInstruction();
            op.LineOrigin = line;

            string[] parts = line.Split(' ');
            op.Argument = Int32.Parse(parts[1]);
            switch (parts[0])
            {
                case "nop":
                    op.Action = op.NoOperation;
                    op.FlipAction = op.Jump;
                    op.Undo = op.UndoNoOperation;
                    op.UndoFlip = op.UndoJump;
                    break;
                case "acc":
                    op.Action = op.Accumulate;
                    op.Undo = op.UndoAccumulate;
                    break;
                case "jmp":
                    op.Action = op.Jump;
                    op.FlipAction = op.NoOperation;
                    op.Undo = op.UndoJump;
                    op.UndoFlip = op.UndoNoOperation;
                    break;
            }

            return op;
        }

        public bool IsJumpOrNop()
        {
            return Action == Jump || Action == NoOperation;
        }

        public string Describe(OpcodeMachine opcodeMachine)
        {
            if (Action == Jump)
                return $"jmp {opcodeMachine.InstructionPointer + Argument} ({this.LineOrigin})";
            else if (Action == NoOperation)
                return $"nop {opcodeMachine.InstructionPointer + Argument} ({this.LineOrigin})";
            else
                return this.ToString();
        }

        public void NoOperation(OpcodeMachine opm)
        {
            opm.InstructionPointer++;
        }

        public void UndoNoOperation(OpcodeMachine opm)
        {
            opm.InstructionPointer--;
        }

        public void Accumulate(OpcodeMachine opm)
        {
            opm.Accumulator += Argument;
            opm.InstructionPointer++;
        }

        public void UndoAccumulate(OpcodeMachine opm)
        {
            opm.Accumulator -= Argument;
            opm.InstructionPointer--;
        }

        public void Jump(OpcodeMachine opm)
        {
            opm.InstructionPointer += Argument;
        }

        public void UndoJump(OpcodeMachine opm)
        {
            opm.InstructionPointer -= Argument;
        }

        public override string ToString()
        {
            return LineOrigin;
        }
    }
}

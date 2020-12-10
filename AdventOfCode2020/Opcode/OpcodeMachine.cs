using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2020.Opcode
{
    public class OpcodeMachine
    {
        public int Accumulator { get; set; } = 0;
        public int InstructionPointer { get; set; } = 0;
        public OpcodeInstruction[] Opcodes { get; set; }
        Stack<OpcodeInstruction> OpcodeHistory { get; set; } = new Stack<OpcodeInstruction>();

        public OpcodeMachine(OpcodeInstruction[] opcodes) 
        {
            Opcodes = opcodes;
        }

        public void Run()
        {
            InstructionPointer = 0;
            while (InstructionPointer < Opcodes.Length)
            {
                ExecuteOrThrow(Opcodes[InstructionPointer]);
            }
        }

        private void ExecuteOrThrow(OpcodeInstruction opcode)
        {
            if (opcode.AlreadyExecuted)
                throw new OpcodeAlreadyExecutedException(Accumulator, InstructionPointer, Opcodes[InstructionPointer]);
            Execute(opcode);
        }

        private void ExecuteOrRewindAndBranch(OpcodeInstruction opcode)
        {
            if (opcode.AlreadyExecuted)
            {
                Console.WriteLine($"Blocked at IP {InstructionPointer}. Undoing...");
                OpcodeInstruction previousOpcode;
                do
                {
                    previousOpcode = OpcodeHistory.Pop();
                    previousOpcode.AlreadyExecuted = false;
                    previousOpcode.Undo(this);
                    Console.WriteLine("Undoing {" + InstructionPointer + "} " + previousOpcode);
                } while (!previousOpcode.IsJumpOrNop());
                while (true)
                {
                    Console.WriteLine("Flipping {" + InstructionPointer + "} " + previousOpcode);
                    previousOpcode.AlreadyExecuted = true;
                    previousOpcode.FlipAction(this);
                    OpcodeHistory.Push(previousOpcode);
                    try
                    {
                        RunUntilTheEnd();
                        Console.WriteLine("Run successful, accumulator is " + Accumulator);
                        return;
                    }
                    catch (Exception)
                    {
                        OpcodeInstruction branchOpCode = OpcodeHistory.Pop();
                        while (branchOpCode != previousOpcode)
                        {
                            branchOpCode.AlreadyExecuted = false;
                            branchOpCode.Undo(this);
                            Console.WriteLine("Undoing {" + InstructionPointer + "} " + branchOpCode);
                            branchOpCode = OpcodeHistory.Pop();
                        }
                        branchOpCode.AlreadyExecuted = false;
                        Console.WriteLine("Undoing flip {" + InstructionPointer + "} " + branchOpCode);
                        branchOpCode.UndoFlip(this);
                        do
                        {
                            previousOpcode = OpcodeHistory.Pop();
                            previousOpcode.AlreadyExecuted = false;
                            previousOpcode.Undo(this);
                            Console.WriteLine("Undoing {" + InstructionPointer + "} " + previousOpcode);
                        } while (!previousOpcode.IsJumpOrNop());
                    }
                }
            }
            else
            {
                Console.WriteLine("Doing {" + InstructionPointer + "} " + opcode);
                Execute(opcode);
            }
        }

        private void RunUntilTheEnd()
        {
            while (InstructionPointer < Opcodes.Length)
            {
                ExecuteOrThrow(Opcodes[InstructionPointer]);
            }
        }

        private void Execute(OpcodeInstruction opcode)
        {
            OpcodeHistory.Push(opcode);
            opcode.AlreadyExecuted = true;
            opcode.Action(this);
        }

        public void Dump()
        {
            InstructionPointer = 0;
            while (InstructionPointer < Opcodes.Length)
            {
                var opcode = Opcodes[InstructionPointer];
                Console.WriteLine("{" + InstructionPointer + "} [" + (opcode.AlreadyExecuted ? "X" : " ") + "] " + opcode.Describe(this));
                InstructionPointer++;
            }
        }

        public void BreakLoop()
        {
            InstructionPointer = 0;
            while (InstructionPointer < Opcodes.Length)
            {
                ExecuteOrRewindAndBranch(Opcodes[InstructionPointer]);
            }
        }
    }

    public class Snapshot
    {
        public int InstructionPointer { get; set; }
        public int Accumulator { get; set; }

        public Snapshot(int accumulator, int instructionPointer)
        {
            Accumulator = accumulator;
            InstructionPointer = instructionPointer;
        }
    }
}

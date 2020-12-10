using AdventOfCode.Elves.IOHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode2020.Opcode;

namespace AdventOfCode2020.Days
{
    public class DayEight
    {
        public static void PartOne()
        {
            Console.WriteLine("Day eight - Part One");
            OpcodeInstruction[] opcodes = PuzzleInputHelper.GetInputLines("DayEight.txt")
                .Select(OpcodeInstruction.FromLine).ToArray();
            OpcodeMachine opm = new OpcodeMachine(opcodes);
            opm.Run();
            Console.WriteLine("Day eight - End of part One");
        }

        //2037 too high
        public static void PartTwo()
        {
            Console.WriteLine("Day eight - Part Two");
            OpcodeInstruction[] opcodes = PuzzleInputHelper.GetInputLines("DayEight.txt")
                .Select(OpcodeInstruction.FromLine).ToArray();
            OpcodeMachine opm = new OpcodeMachine(opcodes);

            try
            {
                opm.BreakLoop();
                Console.WriteLine("Program terminated with accumulator = " + opm.Accumulator);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            Console.WriteLine("Day eight - End of Part Two");
        }
    }
}

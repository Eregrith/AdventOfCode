using AdventOfCode2019.Intcode;
using System;
using System.IO;
using System.Net;

namespace AdventOfCode2019
{
    partial class Program
    {
        static void Main()
        {
            DayTwentyOne.PartTwo();
        }

        private static void DecompileAndLabelizeIntcodes()
        {
            string[] intcodeFiles = new[] { "11", "13", "15", "17", "19", "2", "21", "5", "7", "9" };
            foreach (string file in intcodeFiles)
            {
                IntcodeDecompiler decom = new IntcodeDecompiler();
                DecompileFile(file, decom);
                LabelizeFile(file, decom);
            }
        }

        private static void DecompileFile(string file, IntcodeDecompiler decom)
        {
            long[] data = InputHelper.GetIntcodeFromFile(file);

            string text = String.Join(Environment.NewLine, decom.Decompile(data));
            File.WriteAllText(InputHelper.GetOutputPathForFile(file + "_decompiled"), text);
            Console.WriteLine(file + "_decompiled ok");
        }

        private static void LabelizeFile(string file, IntcodeDecompiler decom)
        {
            long[] data = InputHelper.GetIntcodeFromFile(file);

            string text = String.Join(Environment.NewLine, decom.Labelize(data));
            File.WriteAllText(InputHelper.GetOutputPathForFile(file + "_labelized"), text);
            Console.WriteLine(file + "_labelized ok");
        }
    }
}

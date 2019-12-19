using AdventOfCode2019.Intcode;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AdventOfCode2019
{
    public static class DayNineteen
    {
        public static void PartOne()
        {
            long[] data = InputHelper.GetIntcodeFromFile("19");

            StringBuilder sb = new StringBuilder();
            for (int y = 810; y < 1047; y++)
            {
                for (int x = 840; x < 1047; x++)
                {
                    IntcodeComputer com = new IntcodeComputer(data, IntcodeMode.Quiet);
                    com.InputQueue.Enqueue(x);
                    com.InputQueue.Enqueue(y);
                    com.Run();
                    if (com.OutputQueue.Dequeue() == 0)
                        sb.Append('.');
                    else
                    {
                        if (y >= 812 && x >= (845 + 84)
                            && y < 912 && x < (945 + 84))
                            sb.Append('X');
                        else
                            sb.Append('#');
                    }
                }
                sb.AppendLine();
            }

            File.WriteAllText(InputHelper.GetOutputPathForFile("19_big_offset"), sb.ToString());
        }
    }
}

using System.IO;
using System.Reflection;

namespace AdventOfCode2019
{
    partial class Program
    {
        public class InputHelper
        {
            public static string GetInputFromFile(string name)
            {
                string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @$"../../../InputFiles/{name}.txt");
                return File.ReadAllText(path);
            }
        }
    }
}

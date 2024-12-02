// See https://aka.ms/new-console-template for more information

using System.Reflection;
using System.Security.Claims;
using System.Text.RegularExpressions;
using AdventOfCode.Elves.IOHelpers;
using AdventOfCode2024.Days;

Console.WriteLine("Hello, World!");

PuzzleInputHelper puzzleInputHelper = new PuzzleInputHelper();

string? input = null;
while (input != "exit")
{
    Console.Write("> ");
    input = Console.ReadLine();
    if (input != null)
    {
        input = input.Trim();
        if (input.StartsWith("run"))
        {
            Regex regex = new Regex(@"run\s+(?<day>\d+)(?:\.(?<part>\d))?");
            Match match = regex.Match(input);
            string dayNumber = match.Groups["day"].Value;
            string? partNumber = match.Groups["part"]?.Value;
            string dayClassName = $"Day{dayNumber.PadLeft(2, '0')}";
            Type? dayType = Type.GetType($"AdventOfCode2024.Days.{dayClassName}");
            if (dayType != null)
            {
                object day = Activator.CreateInstance(dayType, puzzleInputHelper);
                if (!String.IsNullOrEmpty(partNumber))
                {
                    string partMethodName = $"Part{partNumber}";
                    MethodInfo? partMethod = dayType.GetMethod(partMethodName);
                    if (partMethod != null)
                    {
                        Console.WriteLine($"Part {partNumber}:");
                        partMethod.Invoke(day, null);
                    }
                    else
                    {
                        Console.WriteLine($"Method {partMethodName} not found in {dayClassName}");
                    }
                }
                else
                {
                    MethodInfo? part1Method = dayType.GetMethod("Part1");
                    if (part1Method != null)
                    {
                        Console.WriteLine("Part 1:");
                        part1Method.Invoke(day, null);
                    }
                    else
                    {
                        Console.WriteLine($"Method Part1 not found in {dayClassName}");
                    }
                    MethodInfo? part2Method = dayType.GetMethod("Part2");
                    if (part2Method != null)
                    {
                        Console.WriteLine("Part 2:");
                        part2Method.Invoke(day, null);
                    }
                    else
                    {
                        Console.WriteLine($"Method Part2 not found in {dayClassName}");
                    }
                }
            }
            else
            {
                Console.WriteLine($"Type {dayClassName} not found");
            }
        }
    }
}

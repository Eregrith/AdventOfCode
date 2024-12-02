using AdventOfCode.Elves.IOHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2020.Days
{
    public class PasswordWithPolicy
    {
        public int FirstPolicyNumber { get; set; }
        public int SecondPolicyNumber { get; set; }
        public char PoliciedChar { get; set; }
        public string SavedPassword { get; set; }

        public PasswordWithPolicy(int firstNumber, int secondNumber, char c, string password)
        {
            FirstPolicyNumber = firstNumber;
            SecondPolicyNumber = secondNumber;
            PoliciedChar = c;
            SavedPassword = password;
        }

        public bool SatisfiesOldPolicy()
        {
            int occurenceCountOfPoliciedChar = SavedPassword.Count(c => c == PoliciedChar);
            return occurenceCountOfPoliciedChar <= SecondPolicyNumber
                && occurenceCountOfPoliciedChar >= FirstPolicyNumber;
        }

        public bool SatisfiesNewPolicy()
        {
            bool policiedCharInMinPosition = SavedPassword[FirstPolicyNumber - 1] == PoliciedChar;
            bool policiedCharInMaxPosition = SavedPassword[SecondPolicyNumber - 1] == PoliciedChar;
            return policiedCharInMinPosition ^ policiedCharInMaxPosition;
        }

        public static PasswordWithPolicy FromLine(string line)
        {
            string[] parts = line.Split(' ');
            string[] minmax = parts[0].Split('-');

            int firstNumber = int.Parse(minmax[0]);
            int secondNumber = int.Parse(minmax[1]);
            char c = parts[1][0];
            string password = parts[2];

            return new PasswordWithPolicy(firstNumber, secondNumber, c, password);
        }
    }

    public class DayTwo
    {
        public static void PartOne()
        {
            Console.WriteLine("Day Two - Part One");
            List<PasswordWithPolicy> passwords = PuzzleInputHelper.GetInputLinesStatic("DayTwo.txt")
                .Select(PasswordWithPolicy.FromLine).ToList();
            int validPasswords = passwords.Count(p => p.SatisfiesOldPolicy());
            Console.WriteLine($"There are {validPasswords} valid passwords under old policy");
            Console.WriteLine("Day Two - End of part One");
        }

        public static void PartTwo()
        {
            Console.WriteLine("Day Two - Part Two");
            List<PasswordWithPolicy> passwords = PuzzleInputHelper.GetInputLinesStatic("DayTwo.txt")
                .Select(PasswordWithPolicy.FromLine).ToList();
            int validPasswords = passwords.Count(p => p.SatisfiesNewPolicy());
            Console.WriteLine($"There are {validPasswords} valid passwords under new policy");
            Console.WriteLine("Day Two - End of part Two");
        }
    }
}

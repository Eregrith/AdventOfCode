using AdventOfCode.Elves.IOHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode.Elves;

namespace AdventOfCode2020.Days
{
    public class Passport
    {
        public Dictionary<string, string> Properties { get; set; } = new Dictionary<string, string>();
        public static List<string> ValidEyeColors { get; } = new List<string> { "amb", "blu", "brn", "gry", "grn", "hzl", "oth" };
        public static List<(string key, Func<string, bool> isValid)> MandatoryProperties { get; } = new List<(string, Func<string, bool>)>
        {
            ( "byr", s => s != null && s.Length == 4 && Int32.Parse(s).IsBetween(1920, 2002)),
            ( "iyr", s => s != null && s.Length == 4 && Int32.Parse(s).IsBetween(2010, 2020)),
            ( "eyr", s => s != null && s.Length == 4 && Int32.Parse(s).IsBetween(2020, 2030)),
            ( "hgt", IsValidHeight),
            ( "hcl", IsValidHairColor),
            ( "ecl", s => ValidEyeColors.Contains(s)),
            ( "pid", s => s != null && s.Length == 9 && s.All(c => "0123456789".Contains(c))),
        };

        private static bool IsValidHairColor(string hcl)
        {
            if (!hcl.StartsWith("#"))
                return false;
            return hcl.Length == 7 && hcl.Substring(1).All(c => "0123456789abcdef".Contains(c));
        }

        private static bool IsValidHeight(string hgt)
        {
            if (!hgt.EndsWith("cm") && !hgt.EndsWith("in"))
                return false;
            int value = Int32.Parse(hgt.Substring(0, hgt.Length - 2));
            if (hgt.EndsWith("cm"))
                return value.IsBetween(150, 193);
            else
                return value.IsBetween(59, 76);
        }

        public static Passport FromLines(List<string> lines)
        {
            Passport passport = new Passport();
            
            foreach (string line in lines)
            {
                string[] parts = line.Split();
                foreach (string part in parts)
                {
                    string[] idValue = part.Split(':');
                    passport.Properties.Add(idValue[0], idValue[1]);
                }
            }
            return passport;
        }

        public override string ToString()
        {
            return $"Password with {Properties.Count} properties:" + String.Join(", ", Properties.Select(p => $"{{{p.Key}}}:{{{p.Value}}}"));
        }

        public bool IsValid()
        {
            return MandatoryProperties.All(p => Properties.ContainsKey(p.key) && !string.IsNullOrEmpty(Properties[p.key]));
        }

        public bool IsDataValid()
        {
            return MandatoryProperties.All(p => Properties.ContainsKey(p.key) && p.isValid(Properties[p.key]));
        }
    }

    public class DayFour
    {
        public static void PartOne()
        {
            Console.WriteLine("Day four - Part One");
            List<List<string>> lines = PuzzleInputHelper.GetInputLinesBatched("DayFour.txt", String.Empty);
            List<Passport> passports = lines.Select(Passport.FromLines).ToList();
            Console.WriteLine($"There are {passports.Count} passports in the file");
            Console.WriteLine($"There are only {passports.Count(p => p.IsValid())} valid passports");
            Console.WriteLine("Day four - End of part One");
        }

        public static void PartTwo()
        {
            Console.WriteLine("Day four - Part Two");
            List<List<string>> lines = PuzzleInputHelper.GetInputLinesBatched("DayFour.txt", String.Empty);
            List<Passport> passports = lines.Select(Passport.FromLines).ToList();
            Console.WriteLine($"There are only {passports.Count(p => p.IsDataValid())} data-valid passports");
            Console.WriteLine("Day four - End of part Two");
        }
    }
}

using AdventOfCode.Elves.IOHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2020.Days
{
    public class Passport
    {
        public Dictionary<string, string> Properties { get; set; } = new Dictionary<string, string>();
        public List<string> MandatoryProperties { get; set; } = new List<string>
        {
            "byr",
            "iyr",
            "eyr",
            "hgt",
            "hcl",
            "ecl",
            "pid"
        };

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
            return MandatoryProperties.All(p => Properties.ContainsKey(p) && !string.IsNullOrEmpty(Properties[p]));
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
    }
}

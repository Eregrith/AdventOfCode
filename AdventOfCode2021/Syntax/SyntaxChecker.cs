using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode2021.Syntax
{
    internal class SyntaxChecker
    {
        private readonly List<string> _lines;
        private readonly Dictionary<char, int> _charScores = new Dictionary<char, int>
        {
            { (char)0, 0 },
            { ')', 3 },
            { ']', 57 },
            { '}', 1197 },
            { '>', 25137 },
        };

        public SyntaxChecker(List<string> lines)
        {
            _lines = lines;
        }

        internal int GetScore()
        {
            return _lines.Sum(l => GetLineScore(l));
        }

        private int GetLineScore(string line)
        {
            char c = GetFirstIllegalChar(line);
            return _charScores[c];
        }

        private char GetFirstIllegalChar(string line)
        {
            Stack<DelimitedBlock> blocks = new Stack<DelimitedBlock>();

            for (int i = 0; i < line.Length; i++)
            {
                char c = line[i];
                if (c.IsBlockOpening())
                {
                    blocks.TryPeek(out DelimitedBlock currentBlock);
                    if (currentBlock != null && currentBlock.ClosingChar == c)
                        currentBlock.OpenedCopies++;
                    else
                        blocks.Push(new DelimitedBlock(c));
                }
                else
                {
                    blocks.TryPeek(out DelimitedBlock currentBlock);
                    if (currentBlock == null || currentBlock.ClosingChar != c)
                    {
                        Console.WriteLine($"Illegal character {c} at position {i}:");
                        Console.WriteLine($"{new String(' ', i)}v");
                        Console.WriteLine(line);
                        Console.WriteLine($"Expected {currentBlock.ClosingChar}");
                        return c;
                    }
                    else
                    {
                        currentBlock.OpenedCopies--;
                        if (currentBlock.OpenedCopies == 0)
                            blocks.Pop();
                    }
                }
            }
            return (char)0;
        }
    }
}

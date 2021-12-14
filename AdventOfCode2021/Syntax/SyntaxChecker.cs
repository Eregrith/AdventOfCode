using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace AdventOfCode2021.Syntax
{
    internal class SyntaxChecker
    {
        private readonly List<string> _lines;
        private readonly Dictionary<char, int> _charSyntaxScores = new Dictionary<char, int>
        {
            { (char)0, 0 },
            { ')', 3 },
            { ']', 57 },
            { '}', 1197 },
            { '>', 25137 },
        };
        private readonly Dictionary<char, int> _charCompletionScores = new Dictionary<char, int>
        {
            { ')', 1 },
            { ']', 2 },
            { '}', 3 },
            { '>', 4 },
        };

        public SyntaxChecker(List<string> lines)
        {
            _lines = lines;
        }

        internal int GetSyntaxCheckerScore()
        {
            return _lines.Sum(l => GetLineScore(l));
        }

        private int GetLineScore(string line)
        {
            char c = GetFirstIllegalChar(line);
            return _charSyntaxScores[c];
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

        internal BigInteger GetAutocompletionScore()
        {
            var scores = _lines.Select(l => GetLineAutocompletionScore(l))
                               .Where(s => s != 0)
                               .OrderByDescending(s => s)
                               .ToList();

            Console.WriteLine($"There are {scores.Count} scores");

            return scores.ElementAt((scores.Count / 2));
        }

        private BigInteger GetLineAutocompletionScore(string line)
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
                        return 0;
                    else
                    {
                        currentBlock.OpenedCopies--;
                        if (currentBlock.OpenedCopies == 0)
                            blocks.Pop();
                    }
                }
            }

            return GetScoreForCompletingBlocks(blocks);
        }

        private BigInteger GetScoreForCompletingBlocks(Stack<DelimitedBlock> blocks)
        {
            BigInteger score = 0;
            while (blocks.Count > 0)
            {
                DelimitedBlock block = blocks.Pop();
                while (block.OpenedCopies > 0)
                {
                    score = score * 5 + _charCompletionScores[block.ClosingChar];
                    block.OpenedCopies--;
                }
            }
            return score;
        }
    }
}

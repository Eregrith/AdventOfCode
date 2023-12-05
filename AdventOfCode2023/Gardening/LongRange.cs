using System.Diagnostics;

namespace AdventOfCode2023.Gardening
{
    [DebuggerDisplay("{Start} => {End} (Size {Size}) Mapped: [{Mapped}]")]
    public class LongRange
    {
        public long Start { get; }
        public long End { get; }
        public long Size => End - Start;
        public bool Mapped = false;

        public LongRange(long start, long end)
        {
            Start = start;
            End = end;
        }

        internal bool Intersects(long start, long end)
        {
            return Start <= end && End >= start;
        }

        public override string ToString()
        {
            return $"{Start} => {End} (Size {Size}) Mapped: [{Mapped}]";
        }
    }
}
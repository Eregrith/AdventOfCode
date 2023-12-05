namespace AdventOfCode2023.Gardening
{
    internal class MappedLongRange : LongRange
    {
        public MappedLongRange(long start, long end, long offset)
            : base(start + offset, end + offset)
        {
            Mapped = true;
        }
    }
}
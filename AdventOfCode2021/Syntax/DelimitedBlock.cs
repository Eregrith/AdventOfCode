namespace AdventOfCode2021.Syntax
{
    internal class DelimitedBlock
    {
        private readonly char _char;
        public DelimitedBlock(char c)
        {
            _char = c;
            ClosingChar = c.GetClosingChar();
            OpenedCopies = 1;
        }

        public char ClosingChar { get; private set; }
        public int OpenedCopies { get; internal set; }
    }
}
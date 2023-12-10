namespace AdventOfCode2023.PipeLoops
{
    internal class PipeLoopMatrix
    {
        private Pipe[][] _pipes;

        public int FurthestDistance { get; set; }

        internal static PipeLoopMatrix FromInput(char[][] input)
        {
            var matrix = new PipeLoopMatrix();
            Pipe start = null;

            matrix._pipes = new Pipe[input.Length][];
            for (int y = 0; y < input.Length; y++)
            {
                matrix._pipes[y] = new Pipe[input[y].Length];
                for (int x = 0; x < input[y].Length; x++)
                {
                    if (input[y][x] != '.')
                    {
                        matrix._pipes[y][x] = new Pipe(x, y, input[y][x]);
                        if (input[y][x] == 'S')
                        {
                            start = matrix._pipes[y][x];
                        }
                    }
                }
            }

            CalculateDistancesInLoop(matrix, start);

            return matrix;
        }

        private static void CalculateDistancesInLoop(PipeLoopMatrix matrix, Pipe start)
        {
            Pipe currentPipeA = start;
            Pipe currentPipeB;
            Pipe nextPipeA;
            Pipe nextPipeB;
            int currentDistance = 0;
            start.Distance = currentDistance++;
            Pipe[] connections = FindConnectionsTo(matrix, currentPipeA);
            nextPipeA = connections[0];
            nextPipeA.Distance = currentDistance;
            nextPipeB = connections[1];
            nextPipeB.Distance = currentDistance;
            currentDistance++;
            currentPipeA = nextPipeA;
            currentPipeB = nextPipeB;

            do
            {
                connections = FindConnectionsTo(matrix, currentPipeA);
                nextPipeA = connections[0];
                connections = FindConnectionsTo(matrix, currentPipeB);
                nextPipeB = connections[0];
                nextPipeA.Distance = currentDistance;
                nextPipeB.Distance = currentDistance;
                currentDistance++;
                currentPipeA = nextPipeA;
                currentPipeB = nextPipeB;
            }
            while (currentPipeA.X != currentPipeB.X
                || currentPipeA.Y != currentPipeB.Y);

            matrix.FurthestDistance = currentDistance - 1;
        }

        private static Pipe[] FindConnectionsTo(PipeLoopMatrix matrix, Pipe currentPipeA)
        {
            Pipe[] connections = new Pipe[2];
            int c = 0;
            Pipe left = matrix.At(currentPipeA.X - 1, currentPipeA.Y);
            if (left != null && left.Distance == null && currentPipeA.ConnectsTo(left))
            {
                connections[c++] = left;
            }
            Pipe right = matrix.At(currentPipeA.X + 1, currentPipeA.Y);
            if (right != null && right.Distance == null && currentPipeA.ConnectsTo(right))
            {
                connections[c++] = right;
            }
            Pipe up = matrix.At(currentPipeA.X, currentPipeA.Y - 1);
            if (up != null && up.Distance == null && currentPipeA.ConnectsTo(up))
            {
                connections[c++] = up;
            }
            Pipe down = matrix.At(currentPipeA.X, currentPipeA.Y + 1);
            if (down != null && down.Distance == null && currentPipeA.ConnectsTo(down))
            {
                connections[c++] = down;
            }

            return connections;
        }

        internal Pipe At(int x, int y)
        {
            if (x < 0 || y < 0
                || y >= _pipes.Length
                || x >= _pipes[0].Length)
                return null;
            return _pipes[y][x];
        }
    }
}

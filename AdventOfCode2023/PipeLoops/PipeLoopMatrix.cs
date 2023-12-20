namespace AdventOfCode2023.PipeLoops
{
    internal class PipeLoopMatrix
    {
        private TileElement[][] _pipes;

        public int FurthestDistance { get; set; }

        internal static PipeLoopMatrix FromInput(char[][] input)
        {
            var matrix = new PipeLoopMatrix();
            Pipe start = null;

            matrix._pipes = new TileElement[input.Length][];
            for (int y = 0; y < input.Length; y++)
            {
                matrix._pipes[y] = new TileElement[input[y].Length];
                for (int x = 0; x < input[y].Length; x++)
                {
                    if (input[y][x] != '.')
                    {
                        var pipe = new Pipe(x, y, input[y][x]);
                        matrix._pipes[y][x] = pipe;
                        if (input[y][x] == 'S')
                        {
                            start = pipe;
                        }
                    }
                    else
                    {
                        matrix._pipes[y][x] = new Ground(x, y);
                    }
                }
            }

            CalculateDistancesInLoop(matrix, start);

            RemoveUnconnectedPipes(matrix);

            FillInside(matrix, start);

            return matrix;
        }

        private static void FillInside(PipeLoopMatrix matrix, Pipe start)
        {

        }

        private static void FillGroundAs(PipeLoopMatrix matrix, int x, int y, char position)
        {
            TileElement t = matrix.At(x, y);
            if (t != null && t is Ground g && g.Position == '?')
            {
                g.Position = position;
                FillGroundAs(matrix, x + 1, y, position);
                FillGroundAs(matrix, x - 1, y, position);
                FillGroundAs(matrix, x, y + 1, position);
                FillGroundAs(matrix, x, y - 1, position);
            }
        }

        private static void RemoveUnconnectedPipes(PipeLoopMatrix matrix)
        {
            for (int y = 0; y < matrix._pipes.Length; y++)
            {
                for (int x = 0; x < matrix._pipes[y].Length; x++)
                {
                    if (matrix._pipes[y][x].Distance == null)
                    {
                        matrix._pipes[y][x] = new Ground(x, y);
                    }
                }
            }
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
            Pipe up = matrix.At(currentPipeA.X, currentPipeA.Y - 1) as Pipe;
            if (up != null && up.Distance == null && currentPipeA.ConnectsTo(up))
            {
                connections[c++] = up;
            }
            Pipe right = matrix.At(currentPipeA.X + 1, currentPipeA.Y) as Pipe;
            if (right != null && right.Distance == null && currentPipeA.ConnectsTo(right))
            {
                connections[c++] = right;
            }
            Pipe down = matrix.At(currentPipeA.X, currentPipeA.Y + 1) as Pipe;
            if (down != null && down.Distance == null && currentPipeA.ConnectsTo(down))
            {
                connections[c++] = down;
            }
            Pipe left = matrix.At(currentPipeA.X - 1, currentPipeA.Y) as Pipe;
            if (left != null && left.Distance == null && currentPipeA.ConnectsTo(left))
            {
                connections[c++] = left;
            }

            return connections;
        }

        internal TileElement At(int x, int y)
        {
            if (x < 0 || y < 0
                || y >= _pipes.Length
                || x >= _pipes[0].Length)
                return null;
            return _pipes[y][x];
        }
    }
}

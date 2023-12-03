namespace AdventOfCode2023.ColoredCubesGame
{
    internal class GameLine
    {
        public int Id { get; internal set; }
        public List<GameSequence> Sequences { get; internal set; }
        public int Power
        {
            get
            {
                MinimumCubeStatistics stats = new MinimumCubeStatistics();

                Sequences.ForEach(stats.Examine);

                return stats.Reds * stats.Greens * stats.Blues;
            }
        }

        internal static GameLine ToGameLine(string input)
        {
            string[] parts = input.Split(':', StringSplitOptions.TrimEntries);

            GameLine gameLine = new GameLine
            {
                Id = int.Parse(parts[0].Split(' ')[1])
            };
            string[] sequences = parts[1].Split(';', StringSplitOptions.TrimEntries);
            gameLine.Sequences = new();

            for (int i = 0; i < sequences.Length; i++)
            {
                GameSequence gameSequence = ParseGameSequence(sequences[i]);
                gameLine.Sequences.Add(gameSequence);
            }

            return gameLine;
        }

        private static GameSequence ParseGameSequence(string sequenceToParse)
        {
            GameSequence gameSequence = new GameSequence();

            string[] cubes = sequenceToParse.Split(',', StringSplitOptions.TrimEntries);

            foreach (string cube in cubes)
            {
                CountCubesOfEachColor(gameSequence, cube);
            }

            return gameSequence;
        }

        private static void CountCubesOfEachColor(GameSequence gameSequence, string cube)
        {
            string[] draws = cube.Split(' ');
            int count = int.Parse(draws[0]);
            if (draws[1] == "blue")
            {
                gameSequence.Blues = count;
            }
            else if (draws[1] == "red")
            {
                gameSequence.Reds = count;
            }
            else if (draws[1] == "green")
            {
                gameSequence.Greens = count;
            }
        }

        internal bool IsValid(CubeLimits limits)
        {
            return Sequences.All(s => s.IsValid(limits));
        }
    }
}

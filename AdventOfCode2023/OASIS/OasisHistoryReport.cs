namespace AdventOfCode2023.OASIS
{
    internal class OasisHistoryReport
    {
        public List<int> Values { get; internal set; }
        public int NextValue { get; internal set; }
        public int PreviousValue { get; internal set; }

        internal static OasisHistoryReport FromInput(string input)
        {
            OasisHistoryReport report = new OasisHistoryReport
            {
                Values = input.Split(' ').Select(int.Parse).ToList(),
            };
            List<List<int>> changesHistory = new List<List<int>>();
            List<int> values = report.Values;

            List<int> changes;
            do
            {
                changes = CalculateChangesOn(values);
                if (changes.Any(c => c != 0))
                    changesHistory.Add(changes);
                values = changes;
            } while (changes.Any(c => c != 0));

            int historyLine = changesHistory.Count - 1;
            int nextValueForZeroChange = historyLine >= 0 ? changesHistory[historyLine][^1] : 0;
            int previousValueForZeroChange = historyLine >= 0 ? changesHistory[historyLine][0] : 0;
            while (historyLine > 0)
            {
                historyLine--;
                nextValueForZeroChange = changesHistory[historyLine][^1] + nextValueForZeroChange;
                previousValueForZeroChange = changesHistory[historyLine][0] - previousValueForZeroChange;
            }

            report.NextValue = report.Values[^1] + nextValueForZeroChange;
            report.PreviousValue = report.Values[0] - previousValueForZeroChange;
            return report;
        }

        private static List<int> CalculateChangesOn(List<int> values)
        {
            List<int> changes = new List<int>();
            for (int i = 0; i < values.Count - 1; i++)
            {
                changes.Add(values[i + 1] - values[i]);
            }

            return changes;
        }
    }
}

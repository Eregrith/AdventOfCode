namespace AdventOfCode2023.GhostDesert
{
    internal class DesertMap
    {
        public string Directions { get; private set; }
        public Dictionary<string, MapNode> Nodes { get; private set; }

        internal static DesertMap ParseMap(List<string> lines)
        {
            var map = new DesertMap { Directions = lines[0] };
            map.Nodes = new Dictionary<string, MapNode>();

            for (int i = 2; i < lines.Count; i++)
            {
                string nodeName = lines[i].Substring(0, 3);
                string leftNodeName = lines[i].Substring(7, 3);
                string rightNodeName = lines[i].Substring(12, 3);

                if (!map.Nodes.ContainsKey(leftNodeName))
                {
                    map.Nodes.Add(leftNodeName, new MapNode(leftNodeName));
                }
                MapNode leftNode = map.Nodes[leftNodeName];

                if (!map.Nodes.ContainsKey(rightNodeName))
                {
                    map.Nodes.Add(rightNodeName, new MapNode(rightNodeName));
                }
                MapNode rightNode = map.Nodes[rightNodeName];

                if (!map.Nodes.ContainsKey(nodeName))
                {
                    map.Nodes.Add(nodeName, new MapNode(nodeName));
                }
                map.Nodes[nodeName].Left = leftNode;
                map.Nodes[nodeName].Right = rightNode;
            }

            return map;
        }

        internal int CountGhostStepsTo(string endTarget)
        {
            int steps = 0;
            int currentDirection = 0;
            List<MapNode> currentNodes = Nodes.Where(n => n.Key.EndsWith('A')).Select(m => m.Value).ToList();
            while (currentNodes.Any(c => !c.Name.EndsWith(endTarget)))
            {
                if (currentNodes.Any(c => c.Name.EndsWith(endTarget)))
                {
                    Console.WriteLine($"At step {steps}:");
                    currentNodes.Where(c => c.Name.EndsWith(endTarget)).ToList().ForEach(Console.WriteLine);
                    Console.WriteLine();
                }
                if (Directions[currentDirection] == 'R')
                    currentNodes = currentNodes.Select(c => c.Right).ToList();
                else
                    currentNodes = currentNodes.Select(c => c.Left).ToList();
                currentDirection++;
                if (currentDirection == Directions.Length)
                    currentDirection = 0;
                steps++;
            }
            return steps;
        }

        internal int CountStepsTo(string targetNodeName)
        {
            int steps = 0;
            int currentDirection = 0;
            MapNode currentNode = Nodes["AAA"];
            while (currentNode.Name != targetNodeName)
            {
                if (Directions[currentDirection] == 'R')
                    currentNode = currentNode.Right;
                else
                    currentNode = currentNode.Left;
                currentDirection++;
                if (currentDirection == Directions.Length)
                    currentDirection = 0;
                steps++;
            }
            return steps;
        }
    }
}

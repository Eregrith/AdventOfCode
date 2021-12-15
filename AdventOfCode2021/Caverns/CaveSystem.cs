using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AdventOfCode.Elves;

namespace AdventOfCode2021.Caverns
{
    internal class CaveSystem
    {
        private readonly List<CaveRoom> _rooms = new List<CaveRoom>();

        public CaveSystem(List<string> connections)
        {
            foreach (string connection in connections)
            {
                string[] parts = connection.Split("-");
                CreateConnection(parts[0], parts[1]);
            }
        }

        internal int CountPathsFromTo(string roomStartName, string roomEndName)
        {
            Log($"Starting journey on room {roomStartName}");
            List<List<string>> paths = GetPathsFromTo(new List<string> { roomStartName }, roomStartName, roomEndName, false);
            return paths.Count;
        }

        internal int CountLongPathsFromTo(string roomStartName, string roomEndName)
        {
            Log($"Starting journey on room {roomStartName}");
            List<List<string>> paths = GetPathsFromTo(new List<string> { roomStartName }, roomStartName, roomEndName, true);
            return paths.Count;
        }

        private List<List<string>> GetPathsFromTo(List<string> pathSoFar, string fromName, string toName, bool allowRevisitOnce)
        {
            List<List<string>> paths = new List<List<string>>();
            string depth = new String(' ', pathSoFar.Count);

            CaveRoom start = GetRoom(fromName);
            Log($"{depth}We are in room {start.Name}");
            foreach (CaveRoom connection in start.ConnectedTo)
            {
                Log($"{depth}I see a tunnel going to {connection.Name}");
                if (CanVisitRoomDuringJourney(pathSoFar, connection, allowRevisitOnce))
                {
                    Log($"{depth}A fork in the road happens at {connection.Name}");
                    List<string> fork = pathSoFar.ToList();
                    fork.Add(connection.Name);
                    if (connection.Name != toName)
                    {
                        Log($"{depth}It probably goes deeper. Let's move in and see where it leads...");
                        List<List<string>> subForks = GetPathsFromTo(fork, connection.Name, toName, allowRevisitOnce);
                        Log($"{depth}Coming back from {connection.Name} we have found {subForks.Count} sub-forks in the path");
                        paths = paths.Union(subForks).ToList();
                    }
                    else
                    {
                        Log($"{depth}It's the exit!");
                        paths.Add(fork);
                        Log($"{depth}This full path to the exit is {String.Join(",", fork)}");
                    }
                }
                else
                {
                    Log($"{depth}Our current path so far is {String.Join(",", pathSoFar)}. We already visited {connection.Name} so we can't go there again, let's check the next connection...");
                }
            }
            Log($"{depth}We have looked at all connections from {start.Name}");
            Log($"{depth}From here to the exit, we found {paths.Count} paths");

            return paths;
        }

        private static void Log(string msg)
        {
            //Console.WriteLine(msg);
        }

        private bool CanVisitRoomDuringJourney(List<string> pathSoFar, CaveRoom target, bool allowRevisitOnce)
        {
            if (target.Name == "start") return false;
            if (target.IsBigRoom) return true;

            bool alreadyVisitedTarget = pathSoFar.Contains(target.Name);
            if (!allowRevisitOnce)
                return !alreadyVisitedTarget;

            bool alreadyVisitedARoomTwice = pathSoFar.Any(r => !r.IsCaps() && pathSoFar.Count(p => p == r) == 2);
            return !alreadyVisitedARoomTwice || !alreadyVisitedTarget;
        }

        private void CreateConnection(string roomA, string roomB)
        {
            CaveRoom a = GetOrCreateRoom(roomA);
            CaveRoom b = GetOrCreateRoom(roomB);
            a.ConnectedTo.Add(b);
            b.ConnectedTo.Add(a);
        }

        private CaveRoom GetOrCreateRoom(string roomName)
        {
            CaveRoom room = GetRoom(roomName);
            if (room != null) return room;
            return CreateRoom(roomName);
        }

        private CaveRoom GetRoom(string roomName)
        {
            return _rooms.FirstOrDefault(r => r.Name == roomName);
        }

        private CaveRoom CreateRoom(string roomName)
        {
            CaveRoom room = new CaveRoom
            {
                Name = roomName,
                IsBigRoom = roomName.IsCaps(),
                ConnectedTo = new List<CaveRoom>()
            };
            _rooms.Add(room);
            return room;
        }
    }
}

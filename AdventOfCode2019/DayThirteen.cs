using AdventOfCode2019.Intcode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace AdventOfCode2019
{
    public class Tile
    {
        public enum TileId
        {
            Empty = 0,
            Wall = 1,
            Block = 2,
            Paddle = 3,
            Ball = 4,
            Score = 5
        };
        public TileId Type { get; set; }
        public long X { get; private set; }
        public long Y { get; private set; }
        public long Score { get; set; }

        public Tile(long x, long y, long id)
        {
            X = x;
            Y = y;
            if (X == -1 && Y == 0)
            {
                Type = TileId.Score;
                Score = id;
            }
            else
                Type = (TileId)id;
        }
    }
    public static class DayThirteen
    {
        public static void PartOne()
        {
            long[] data = InputHelper.GetIntcodeFromFile("13");

            IntcodeComputer computer = new IntcodeComputer(data);
            computer.Run();

            List<Tile> tiles = computer.OutputQueue.ToList().Sublists(3).Select(t => new Tile(t[0], t[1], t[2])).ToList();

            int blocks = tiles.Count(t => t.Type == Tile.TileId.Block);
            Console.WriteLine($"There are {blocks} block tiles");
        }

        public static void PartTwo()
        {
            long[] data = InputHelper.GetIntcodeFromFile("13");

            IntcodeComputer computer = new IntcodeComputer(data, IntcodeMode.Quiet | IntcodeMode.Blocking);
            computer.Context.Data[0] = 2;
            List<Tile> tiles = new List<Tile>();
            while (!computer.IsFinished)
            {
                computer.RunUntilInput();
                UpdateTiles(tiles, computer.OutputQueue.ToList().Sublists(3).Select(t => new Tile(t[0], t[1], t[2])).ToList());
                computer.OutputQueue.Clear();
                Display(tiles);
                int currentBallX = (int)tiles.First(t => t.Type == Tile.TileId.Ball).X;
                int currentPadX = (int)tiles.First(t => t.Type == Tile.TileId.Paddle).X;
                computer.InputQueue.Enqueue(currentBallX - currentPadX);
                computer.Step();
            }
        }

        private static void UpdateTiles(List<Tile> tiles, List<Tile> updates)
        {
            foreach (Tile tile in updates)
            {
                if (tiles.Any(t => t.X == tile.X && t.Y == tile.Y))
                {
                    Tile thisTile = tiles.First(t => t.X == tile.X && t.Y == tile.Y);
                    thisTile.Type = tile.Type;
                    thisTile.Score = tile.Score;
                }
                else
                    tiles.Add(tile);
            }
        }

        private static void Display(List<Tile> tiles)
        {
            StringBuilder sb = new StringBuilder();
            for (long y = tiles.Min(t => t.Y); y <= tiles.Max(t => t.Y); y++)
            {
                for (long x = tiles.Min(t => t.X); x <= tiles.Max(t => t.X); x++)
                {
                    char tile = ' ';
                    Tile thisTile = tiles.FirstOrDefault(t => t.X == x && t.Y == y);
                    
                    if (thisTile != null)
                        switch (thisTile.Type)
                        {
                            case Tile.TileId.Empty:
                                tile = ' ';
                                break;
                            case Tile.TileId.Wall:
                                tile = '#';
                                break;
                            case Tile.TileId.Block:
                                tile = 'B';
                                break;
                            case Tile.TileId.Paddle:
                                tile = '_';
                                break;
                            case Tile.TileId.Ball:
                                tile = 'o';
                                break;
                        }
                    sb.Append(tile);
                }
                sb.AppendLine();
            }
            sb.AppendLine($"Score : {tiles.First(t => t.Type == Tile.TileId.Score).Score}");
            Console.WriteLine(sb.ToString());
        }
    }
}

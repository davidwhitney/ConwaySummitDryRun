using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Runner.Core
{
    public class Simulation
    {
        private int _dimensions;
        private List<Location> _livingCells;

        public Simulation(int dimensions = 10)
        {
            _dimensions = dimensions;
            _livingCells = new List<Location>();
        }

        public void Step()
        {
            var subsequentLivingCells = new List<Location>();

            for (int y = 0; y < _dimensions; y++)
            {
                for (int x = 0; x < _dimensions; x++)
                {
                    var location = new Location(x, y);
                    var isAlive = _livingCells.Contains(location);
                    var neighbourLocations = new List<Location>
                    {
                        new Location(location.X + 1, location.Y + 1),
                        new Location(location.X - 1, location.Y + 1),
                        new Location(location.X + 1, location.Y - 1),
                        new Location(location.X - 1, location.Y - 1),
                        new Location(location.X + 1, location.Y),
                        new Location(location.X - 1, location.Y),
                        new Location(location.X, location.Y + 1),
                        new Location(location.X, location.Y - 1),
                    };
                    var countOfLivingNeighours = neighbourLocations.Count(loc => _livingCells.Contains(loc));

                    if (isAlive)
                    {
                        if (countOfLivingNeighours == 2 || countOfLivingNeighours == 3)
                        {
                            subsequentLivingCells.Add(location);
                        }
                    }
                    else
                    {
                        if (countOfLivingNeighours == 3)
                        {
                            subsequentLivingCells.Add(location);
                        }
                    }
                }
            }

            _livingCells = subsequentLivingCells;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            for (var y = 0; y < _dimensions; y++)
            {
                var lineBuilder = new StringBuilder();
                for (var x = 0; x < _dimensions; x++)
                {
                    var val = _livingCells.Contains(new Location(x, y)) ? 'A' : '.';
                    lineBuilder.Append(val);
                }
                sb.AppendLine(lineBuilder.ToString());
            }

            return sb.ToString();
        }

        public void Populate()
        {
            _livingCells = new List<Location>();
            var maxNumberOfCellsThatCanLive = _dimensions * _dimensions;
            var rnd = new Random();

            for (int x = 0; x < maxNumberOfCellsThatCanLive; x++)
            {
                var itLives = rnd.Next(0, 2) == 1;
                if (itLives)
                {
                    var locX = rnd.Next(0, _dimensions + 1);
                    var locY = rnd.Next(0, _dimensions + 1);
                    var location = new Location(locX, locY);
                    if (!_livingCells.Contains(location))
                    {
                        _livingCells.Add(location);
                    }
                }
            }
        }

        public void Populate(string s)
        {
            var lines = s.Split(new[] {Environment.NewLine}, StringSplitOptions.RemoveEmptyEntries);
            _dimensions = lines.First().Length;
            for (var y = 0; y < lines.Length; y++)
            {
                var line = lines[y];
                for (var x = 0; x < line.Length; x++)
                {
                    var ch = line[x];
                    if (ch == 'A')
                    {
                        _livingCells.Add(new Location(x, y));
                    }
                }
            }
        }
    }

    public class Location
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Location(int x, int y)
        {
            X = x;
            Y = y;
        }

        public override bool Equals(object obj)
        {
            var other = obj as Location;
            if (other == null) return false;
            return other.X == X && other.Y == Y;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (X * 397) ^ Y;
            }
        }

        public override string ToString() => $"{{X:{X},{Y}}}";
    }
}

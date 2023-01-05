using System.Text;

namespace AdventOfCode
{
    internal static class DayFourteen
    {
        public class Cave
        {
            public const char Air = '.';
            public const char Rock = '#';
            public const char Sand = 'o';

            private char[][] _cave;
            private int _minX = int.MaxValue, _maxX = int.MinValue, _minY = 0, _maxY = int.MinValue;

            public Cave(int numRow = 1000, int numCol = 1000)
            {
                _cave = new char[numRow][];
                for (var row = 0; row < numRow; row++)
                {
                    _cave[row] = Enumerable.Repeat(Air, numCol).ToArray();
                }
            }

            public void AddRocks(List<(int X, int Y)> input)
            {
                if (input.Count == 0) return;

                // set current rock to first
                var (currX, currY) = input.First();
                Add(currX, currY, Rock);

                // add the rest
                foreach (var (nX, nY) in input.Skip(1))
                {
                    foreach (var (x, y) in GetLine(currX, currY, nX, nY))
                    {
                        Add(x, y, Rock);
                    }
                    currX = nX;
                    currY = nY; 
                }
            }

            public void AddFloor()
            {
                var floorY = _maxY + 2;
                foreach (var (x, y) in GetLine(0, floorY, 999, floorY))
                {
                    Add(x, y, Rock, setMax: false);
                }
            }

            public bool AddSand(int x, int y, bool withFloor = false)
            {
                var falling = true;
                var cX = x;
                var cY = y; 

                do
                {
                    if (falling = CanFall(cX, cY + 1))
                    {
                        cY = cY + 1;
                    }
                    else if (falling = CanFall(cX - 1, cY + 1))
                    {
                        cX = cX - 1;
                        cY = cY + 1;
                    }
                    else if (falling = CanFall(cX + 1, cY + 1))
                    {
                        cX = cX + 1;
                        cY = cY + 1;
                    }

                    if (!withFloor && cY == _maxY) 
                        return false; // falling in to infinity

                    if (withFloor && cX == x && cY == y && _cave[y][x] == Sand)
                        return false; // filed up all we can
                }
                while (falling);

                Add(cX, cY, Sand);

                return true; // came to rest
            }

            public override string ToString()
            {
                var sb = new StringBuilder();
                for (var row = _minY; row <= _maxY + 2; row++) 
                {
                    sb.AppendLine(new string(_cave[row][(_minX - 5)  .. (_maxX + 5)]));
                }
                return sb.ToString();
            }

            private bool CanFall(int x, int y)
            {
                return _cave[y][x] != Rock &&
                       _cave[y][x] != Sand;
            }

            private void Add(int x, int y, char c, bool setMax = true)
            {
                if (setMax)
                {
                    _minX = Math.Min(x, _minX);
                    _maxX = Math.Max(x, _maxX);
                    _maxY = Math.Max(y, _maxY);
                }    
                _cave[y][x] = c;
            }

            private List<(int X, int Y)> GetLine(
                int sX, int sY, int eX, int eY)
            {
                if (sX == eX) // same column
                {
                    var startY = Math.Min(sY, eY);
                    var endY = Math.Max(sY, eY);
                    return Enumerable.Range(startY, (endY - startY) + 1)
                        .Select(y => (sX, y))
                        .ToList();
                }

                if (sY == eY) // same row
                {
                    var startX = Math.Min(sX, eX);
                    var endX = Math.Max(sX, eX);
                    return Enumerable.Range(startX, (endX - startX) + 1)
                        .Select(x => (x, sY))
                        .ToList();
                }

                return new List<(int X, int Y)>(); // not a line?
            }
        }

        public static int One(List<List<(int X, int Y)>> input)
        {
            // setup cave
            var cave = new Cave();
            foreach (var i in input)
            {
                cave.AddRocks(i);
            }

            // find answer
            var addMore = true;
            var numAdded = 0;
            while (addMore)
            {
                addMore = cave.AddSand(500, 0);
                if (addMore)
                    numAdded++;
            }

            return numAdded;
        }

        public static int Two(List<List<(int X, int Y)>> input)
        { 
            // setup cave
            var cave = new Cave();
            foreach (var i in input)
            {
                cave.AddRocks(i);
            }
            cave.AddFloor();

            // find answer
            var addMore = true;
            var numAdded = 0;
            while (addMore)
            {
                addMore = cave.AddSand(500, 0, withFloor: true);
                if (addMore)
                    numAdded++;
            }

            return numAdded;
        }
    }
}

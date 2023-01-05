namespace AdventOfCode
{
    internal static class DayTwelve
    {
        public record Point(int Row, int Col);

        public static char GetVal(List<List<char>> graph, Point p)
        {
            return graph[p.Row][p.Col];
        }

        public static List<Point> GetNeighbors(List<List<char>> graph, Point p)
        {
            var neighbors = new List<Point>();
            if (p.Row + 1 < graph.Count) { neighbors.Add(p with { Row = p.Row + 1 }); }
            if (p.Row - 1 >= 0) { neighbors.Add(p with { Row = p.Row - 1 }); }
            if (p.Col + 1 < graph[0].Count) { neighbors.Add(p with { Col = p.Col + 1 }); }
            if (p.Col - 1 >= 0) { neighbors.Add(p with { Col = p.Col - 1 }); }
            return neighbors
                .Select(n => (Neighbor: n, Climb: GetClimb(graph, n, p)))
                .Where(i => i.Climb <= 1)
                .Select(i => i.Neighbor)
                .ToList();
        }

        public static int GetClimb(List<List<char>> graph, Point next, Point current)
        {
            var nVal = (int)GetVal(graph, next);
            if (nVal == 'E') nVal = 'z' + 1;
            if (nVal == 'S') nVal = 'a';
            var cVal = (int)GetVal(graph, current);
            if (cVal == 'S') cVal = 'a';
            return nVal - cVal;
        }

        public static List<Point> Find(List<List<char>> graph, char val)
        {
            var points = new List<Point>();
            for (var i = 0; i < graph.Count; i++)
            {
                for (var j = 0; j < graph[0].Count; j++)
                {
                    if (graph[i][j] == val) points.Add(new Point(i, j));
                }
            }
            return points;
        }

        public static int FindPathCost(List<List<char>> input, Point start, Point end)
        {
            var frontier = new PriorityQueue<Point, int>(new[] { (start, 0) });
            var cameFrom = new Dictionary<Point, Point>
            { 
                { start, null } 
            };
            var costSoFar = new Dictionary<Point, int>
            { 
                { start, 0 } 
            };

            while (frontier.TryDequeue(out var current, out var _))
            {
                if (current == end) { break; }

                var neighbors = GetNeighbors(input, current);

                foreach (var n in neighbors)
                {
                    var newCost = costSoFar[current] + 1;
                    if (!costSoFar.ContainsKey(n) || newCost < costSoFar[n])
                    {
                        costSoFar[n] = newCost;
                        frontier.Enqueue(n, newCost);
                        cameFrom[n] = current;
                    }
                }
            }

            if (!cameFrom.ContainsKey(end)) { return int.MaxValue; }

            var prev = cameFrom[end];
            var steps = 1;
            while (prev != start)
            {
                prev = cameFrom[prev];
                steps++;
            }

            return steps;
        }

        public static int One(List<List<char>> input)
        {
            var start = Find(input, 'S').First();
            var end = Find(input, 'E').First();
            return FindPathCost(input, start, end);
        }

        public static int Two(List<List<char>> input)
        {
            var starts = Find(input, 'a');
            var end = Find(input, 'E').First();
            return starts
                .Select(s => FindPathCost(input, s, end))
                .Min();
        }
    }
}

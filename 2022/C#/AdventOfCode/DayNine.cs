namespace AdventOfCode
{
    internal static class DayNine
    {
        public record Point(int X, int Y)
        {
            public Point Move(char dir) => dir switch
            {
                'U' => this with { Y = Y - 1 },
                'D' => this with { Y = Y + 1 },
                'R' => this with { X = X + 1 },
                'L' => this with { X = X - 1 }
            };

            public Point MoveTowards(Point p)
            {
                var ret = this;
                var dx = p.X - X;
                var dy = p.Y - Y;
                var adx = Math.Abs(dx);
                var ady = Math.Abs(dy);

                if (adx == 2)
                {
                    ret = ret with { X = ret.X + (dx > 0 ? 1 : -1), Y = ret.Y + (ady == 1 ? dy : 0) };
                }

                if (ady == 2)
                {
                    ret = ret with { Y = ret.Y + (dy > 0 ? 1 : -1), X = ret.X + (adx == 1 ? dx : 0) };
                }

                return ret;
            }

            public List<Point> GetNeighbors() =>
                new List<Point>
                {
                    new Point(X, Y),
                    new Point(X + 1, Y),
                    new Point(X - 1, Y),
                    new Point(X, Y + 1),
                    new Point(X, Y - 1),
                    new Point(X + 1, Y - 1),
                    new Point(X - 1, Y - 1),
                    new Point(X + 1, Y + 1),
                    new Point(X - 1, Y + 1),
                };
        };

        public static int One(List<(char Dir, int Amt)> input)
        {
            static (Point Head, Point Tail) MoveHead(
                Point head,
                Point tail,
                int amount,
                Func<Point, Point> getHead,
                Func<Point, Point> getTail,
                HashSet<Point> visited)
            {
                for (var i = 0; i < amount; i++)
                {
                    head = getHead(head);
                    if (!tail.GetNeighbors().Contains(head))
                    {
                        tail = getTail(head);
                    }
                    visited.Add(tail);
                }

                return (head, tail);
            }

            var head = new Point(0, 0);
            var tail = new Point(0, 0);
            var visited = new HashSet<Point>();

            foreach (var (dir, amt) in input)
            {
                switch (dir)
                {
                    case 'R':
                        (head, tail) = MoveHead(head, tail, amt, p => p with { X = p.X + 1 }, p => p with { X = p.X - 1 }, visited);
                        break;
                    case 'L':
                        (head, tail) = MoveHead(head, tail, amt, p => p with { X = p.X - 1 }, p => p with { X = p.X + 1 }, visited);
                        break;
                    case 'U':
                        (head, tail) = MoveHead(head, tail, amt, p => p with { Y = p.Y + 1 }, p => p with { Y = p.Y - 1 }, visited);
                        break;
                    case 'D':
                        (head, tail) = MoveHead(head, tail, amt, p => p with { Y = p.Y - 1 }, p => p with { Y = p.Y + 1 }, visited);
                        break;
                }
            }

            return visited.Count();
        }

        public static int Two(List<(char Dir, int Amt)> input)
        {
            var tailVisited = new HashSet<Point>();

            var knots = Enumerable.Range(0, 10)
                .Select(_ => new Point(0, 0))
                .ToList();

            foreach (var (dir, amt) in input)
            {
                foreach (var _ in Enumerable.Range(0, amt))
                {
                    // move head

                    knots[0] = knots[0].Move(dir);

                    // move others

                    for (var i = 1; i < knots.Count; i++)
                    {
                        knots[i] = knots[i].MoveTowards(knots[i - 1]);
                    }

                    // add to visited

                    tailVisited.Add(knots[^1]);
                }
            }

            return tailVisited.Count;
        }
    }
}

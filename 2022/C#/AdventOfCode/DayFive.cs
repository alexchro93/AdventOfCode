namespace AdventOfCode
{
    internal static class DayFive
    {
        public static string One(List<Stack<char>> stacks, List<string> instructions)
        {
            foreach (var i in instructions)
            {
                var items = i.Split(" ");
                var src = int.Parse(items[3]);
                var dst = int.Parse(items[5]);
                var num  = int.Parse(items[1]);
                foreach (var _ in Enumerable.Range(0, num))
                {
                    stacks[dst].Push(stacks[src].Pop());
                }
            }

            var ret = stacks.Skip(1).Aggregate("", (r, s) => r + s.Peek());

            return ret;
        }

        public static string Two(List<Stack<char>> stacks, List<string> instructions)
        {            
            foreach (var i in instructions)
            {
                var items = i.Split(" ");
                var src = int.Parse(items[3]);
                var dst = int.Parse(items[5]);
                var num  = int.Parse(items[1]);
                var moved = new List<char>();
                foreach (var _ in Enumerable.Range(0, num))
                {
                    if (stacks[src].Any())
                        moved.Insert(0, stacks[src].Pop());
                }
                foreach (var c in moved)
                {
                    stacks[dst].Push(c);
                }
            }

            var ret = stacks.Skip(1).Aggregate("", (r, s) => r + s.Peek());

            return ret;
        }
    }
}

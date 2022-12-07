namespace AdventOfCode
{
    internal static class DayThree
    {
        private static List<char> items;

        static DayThree()
        {
            items = "_abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ".ToList();
        }

        public static int One(string[] inp)
        {
            return inp
                .Select(i => (i.Substring(0, i.Length / 2), i.Substring(i.Length / 2)))
                .Select(i => i.Item1.Intersect(i.Item2).First())
                .Sum(i => items.IndexOf(i));
        }

        public static int Two(string[] inp)
        {
            return inp
                .Chunk(3)
                .Select(chunk =>
                {
                    return chunk.Aggregate((i, j) => string.Concat(i.Intersect(j))).First();
                })
                .Sum(items.IndexOf);
        }
    }
}

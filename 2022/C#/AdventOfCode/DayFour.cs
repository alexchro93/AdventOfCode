namespace AdventOfCode
{
    internal static class DayFour
    {
        public static int One(List<((int, int), (int, int))> inp)
        {
            var count = 0;
            foreach(var (one, two) in inp)
            {
                if (one.Item1 <= two.Item1 && one.Item2 >= two.Item2) 
                    count++;
                else if (two.Item1 <= one.Item1 && two.Item2 >= one.Item2) 
                    count++;
            }
            return count;
        }

        public static int Two(List<((int, int), (int, int))> inp)
        {
            var count = 0;
            foreach(var (one, two) in inp)
            {
                var rangeOne = Enumerable.Range(one.Item1, one.Item2 - one.Item1 + 1);
                var rangeTwo = Enumerable.Range(two.Item1, two.Item2 - two.Item1 + 1);
                if (rangeOne.Intersect(rangeTwo).Any())
                    count++;
            }
            return count;
        }
    }
}

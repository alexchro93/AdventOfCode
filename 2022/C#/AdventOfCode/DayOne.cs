namespace AdventOfCode
{
    internal static class DayOne
    {
        public static int One(List<int> calories)
        {
            var max = 0;
            var cur = 0;
            foreach (var val in calories)
            {
                if (val == int.MinValue)
                {
                    if (cur > max) { max = cur; }
                    cur = 0;
                }
                else
                {
                    cur += val;
                }
            }
            return max;
        }

        public static int Two(List<int> calories)
        {
            static void KeepLargest(int[] items, int item)
            {
                int curr = item;
                for (var i = 0; i < items.Length; i++)
                {
                    if (items[i] < curr)
                    {
                        (curr, items[i]) = (items[i], curr);
                    }
                }
            }

            var items = new int[3] { 0, 0, 0 };
            var cur = 0;

            foreach (var val in calories)
            {
                if (val == int.MinValue)
                {
                    KeepLargest(items, cur);
                    cur = 0;
                }
                else
                {
                    cur += val;
                }
            }

            return items.Sum();
        }
    }
}

namespace AdventOfCode
{
    internal static class DaySix
    {
        public static int One(string input)
        {
            var items = new char[4];
            for (var i = 0; i < input.Length; i++)
            {
                var temp = new char[4];
                Array.Copy(items, 0, temp, 1, 3);
                items = temp;
                items[0] = input[i];
                if (i >= 3 && items.Distinct().Count() == 4)
                    return i + 1;
            }
            return -1;
        }

        public static int Two(string input)
        {
            var items = new char[14];
            for (var i = 0; i < input.Length; i++)
            {
                var temp = new char[14];
                Array.Copy(items, 0, temp, 1, 13);
                items = temp;
                items[0] = input[i];
                if (i >= 14 && items.Distinct().Count() == 14)
                    return i + 1;
            }
            return -1;
        }
    }
}

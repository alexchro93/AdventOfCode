using System.Drawing;

namespace AdventOfCode
{
    public static class DaySeven
    {
        private record Item(string Name) { public Guid Id = Guid.NewGuid(); };

        private record Directory(string Name, Directory Parent, List<Item> Contents) : Item(Name);

        private record File(string Name, long Size) : Item(Name);

        public static long One(List<string> input)
        {
            var root = new Directory("/", null, new List<Item>());

            PopulateItems(root, input);

            var sizes = new Dictionary<Guid, long>();
            PopulateSizes(root, sizes);

            return sizes.Where(kvp => kvp.Value <= 100_000L).Sum(kvp => kvp.Value);
        }

        public static long Two(List<string> input)
        {            
            var root = new Directory("/", null, new List<Item>());

            PopulateItems(root, input);

            var sizes = new Dictionary<Guid, long>();
            PopulateSizes(root, sizes);

            var needed = 30_000_000 - (70_000_000 - sizes[root.Id]);
            return sizes.Where(kvp => kvp.Value >= needed).Min(kvp => kvp.Value);
        }

        private static void PopulateItems(Directory root, List<string> input)
        {
            var current = root;
            foreach (var item in input.Skip(1))
            {
                var parts = item.Split(" ");
                if (parts[0] == "$")
                {
                    var command = parts[1];
                    var arg = parts.Length == 3 ? parts[2] : string.Empty;

                    if (command == "cd")
                    {
                        if (arg == "..") { current = current.Parent; }
                        else if (arg == "/") { current = root; }
                        else { current = current.Contents.First(c => c.Name == arg) as Directory; }
                    }
                }
                else if (parts[0] == "dir")
                {
                    current.Contents.Add(new Directory(parts[1], current, new List<Item>()));
                }
                else
                {
                    current.Contents.Add(new File(parts[1], long.Parse(parts[0])));
                }
            }
        }

        private static void PopulateSizes(Directory root, Dictionary<Guid, long> sizes)
        {
            var size = 0L;
            foreach (var item in root.Contents)
            {
                if (item is File f) { size += f.Size; }
                if (item is Directory d)
                {
                    PopulateSizes(d, sizes);
                    size += sizes[d.Id];
                }
            }
            sizes[root.Id] = size;
        }
    }
}

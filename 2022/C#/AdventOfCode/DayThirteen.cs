using System.Text;

namespace AdventOfCode
{
    internal static class DayThirteen
    {
        public record Data;

        public record IntData(int Value) : Data
        {
            public override string ToString() => Value.ToString();
        }

        public record ListData(List<Data> Values) : Data, IComparable<ListData>
        {
            public Data this[int i] => Values[i];

            public int Count => Values.Count;

            public override string ToString()
            {
                return $"[{string.Join(',', Values)}]";
            }

            int IComparable<ListData>.CompareTo(ListData? other)
            {
                return Compare(this, other);
            }
        }

        public class PacketProcessor
        {
            private string _packet;
            private int _position;

            public PacketProcessor(string packet) 
            {
                _packet = packet;
                _position = 0;
            }

            public bool TryGetNextPart(out string part)
            {
                part = string.Empty;
                var found = false;
                while (!found && _position < _packet.Length)
                {
                    var current = _packet[_position];
                    if (current == '[' || current == ']')
                    {
                        part += current;
                        found = true;
                    }
                    else if (char.IsDigit(current))
                    {
                        part += current;
                        if (!char.IsDigit(_packet[_position + 1]))
                        {
                            found = true;
                        }
                    }
                    _position++;
                }
                return found;
            }

            public ListData Parse()
            {
                Stack<ListData> contents = new();
                ListData current = null;
                while (TryGetNextPart(out var part))
                {
                    if (part == "[")
                    {
                        if (current != null) { contents.Push(current); }
                        current = new ListData(new List<Data>());
                    }
                    else if (part == "]")
                    {
                        if (contents.TryPop(out var nextCurrent))
                        {
                            nextCurrent.Values.Add(current);
                            current = nextCurrent;
                        }
                    }
                    else if (int.TryParse(part, out var val))
                    {
                        current.Values.Add(new IntData(val));
                    }
                }
                return current;
            }
        }

        public static int Compare(ListData left, ListData right)
        {
            for (var i = 0; i <= left.Count; i++)
            {
                var l = (i < left.Count) ? left.Values[i] : null;
                var r = (i < right.Count) ? right.Values[i] : null;

                if (l is null && r is not null)
                {
                    return -1;
                }
                else if (l is not null && r is null)
                {
                    return 1;
                }
                else if (l is IntData iLeft && r is IntData iRight)
                {
                    if (iLeft.Value < iRight.Value)
                        return -1;
                    if (iLeft.Value > iRight.Value)
                        return 1;
                }
                else if ( ( l is ListData && r is IntData  ) || 
                          ( l is IntData && r is ListData  ) ||
                          ( l is ListData && r is ListData ) )
                {
                    var listL = l is ListData lstL ? lstL : new ListData(new List<Data> { l });
                    var listR = r is ListData lstR ? lstR : new ListData(new List<Data> { r });
                    var same = Compare(listL, listR);
                    if (same != 0)
                        return same;
                }
            }
            return 0;
        }

        public static int One(List<(string Left, string Right)> input)
        {
            var sum = 0;
            for (var i = 0; i < input.Count; i++)
            {
                var (left, right)  = input[i];
                var leftData = (new PacketProcessor(left)).Parse();
                var rightData = (new PacketProcessor(right)).Parse();
                if (Compare(leftData, rightData) == -1)
                {
                    sum += i + 1;
                }
            }
            return sum;
        }

        public static int Two(List<(string Left, string Right)> input)
        {
            var div1 = new ListData(new List<Data> { new ListData(new List<Data> { new IntData(2) }) });
            var div2 = new ListData(new List<Data> { new ListData(new List<Data> { new IntData(6) }) });

            var items = input
                .SelectMany(i =>
                {
                    var leftData = (new PacketProcessor(i.Left)).Parse();
                    var rightData = (new PacketProcessor(i.Right)).Parse();
                    return new[] { leftData, rightData };
                })
                .Concat(new[] { div1, div2 })
                .Order()
                .ToList();

            var iOne = items.FindIndex(i => i.Equals(div1)) + 1;
            var iTwo = items.FindIndex(i => i.Equals(div2)) + 1;

            return iOne * iTwo;
        }
    }
}

namespace AdventOfCode
{
    internal enum Hand
    {
        Rock,
        Paper,
        Scissors
    }

    internal static class DayTwo
    {
        public static int One(List<(Hand, Hand)> inp)
        {
            var score = 0;
            foreach (var (opp, you) in inp)
            {
                if (opp == Hand.Rock)
                {
                    if (you == Hand.Rock)
                    {
                        score += 1 + 3;
                    } 
                    else if (you == Hand.Paper)
                    {
                        score += 2 + 6;
                    } 
                    else if (you == Hand.Scissors)
                    {
                        score += 3 + 0;
                    }
                } 
                else if (opp == Hand.Paper)
                { 
                    if (you == Hand.Rock)
                    {
                        score += 1 + 0;
                    } 
                    else if (you == Hand.Paper)
                    {
                        score += 2 + 3;
                    } 
                    else if (you == Hand.Scissors)
                    {
                        score += 3 + 6;
                    }
                } 
                else if (opp == Hand.Scissors)
                {
                    if (you == Hand.Rock)
                    {
                        score += 1 + 6;
                    } 
                    else if (you == Hand.Paper)
                    {
                        score += 2 + 0;
                    } 
                    else if (you == Hand.Scissors)
                    {
                        score += 3 + 3;
                    }
                }
            }
            return score;
        }

        public static int Two(List<(Hand, Hand)> inp)
        {
            var score = 0;
            foreach (var (opp, you) in inp)
            {
                if (opp == Hand.Rock)
                {
                    if (you == Hand.Rock)
                    {
                        score += 3 + 0;
                    } 
                    else if (you == Hand.Paper)
                    {
                        score += 1 + 3;
                    } 
                    else if (you == Hand.Scissors)
                    {
                        score += 2 + 6;
                    }
                } 
                else if (opp == Hand.Paper)
                { 
                    if (you == Hand.Rock)
                    {
                        score += 1 + 0;
                    } 
                    else if (you == Hand.Paper)
                    {
                        score += 2 + 3;
                    } 
                    else if (you == Hand.Scissors)
                    {
                        score += 3 + 6;
                    }
                } 
                else if (opp == Hand.Scissors)
                {
                    if (you == Hand.Rock)
                    {
                        score += 2 + 0;
                    } 
                    else if (you == Hand.Paper)
                    {
                        score += 3 + 3;
                    } 
                    else if (you == Hand.Scissors)
                    {
                        score += 1 + 6;
                    }
                }
            }
            return score;
        }
    }
}

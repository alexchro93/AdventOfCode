namespace AdventOfCode
{
    internal static class DayEight
    {
        public static int One(List<List<int>> input)
        {
            bool IsVisible(int i, int j, Func<int, int> newI, Func<int, int> newJ)
            {
                var currI = newI(i);
                var currJ = newJ(j);
                var done = false;

                while (!done)
                {
                    if (currI < 0 || currI >= input.Count) 
                    { 
                        done = true; 
                    }
                    else
                    {
                        var row = input[currI];
                        if (currJ < 0 ||  currJ >= row.Count) 
                        { 
                            done = true; 
                        }
                        else
                        {
                            if (input[i][j] <= row[currJ]) 
                            { 
                                return false; 
                            }
                        }
                    }
                    currI = newI(currI);
                    currJ = newJ(currJ);
                }

                return true;
            }

            var visible = 0;
            for (var i = 0; i < input.Count; i++)
            {
                for (var j = 0; j < input[i].Count; j++)
                {
                    if ( i == 0 || 
                         j == 0 ||
                         i == input.Count - 1 ||
                         j == input[i].Count - 1 )
                    {
                        visible++;
                    }
                    else
                    {
                        if ( IsVisible(i, j, i => i + 1, j => j) ||
                             IsVisible(i, j, i => i - 1, j => j) ||
                             IsVisible(i, j, i => i, j => j + 1) ||
                             IsVisible(i, j, i => i, j => j - 1) )
                        {
                            visible++;
                        }
                    }
                }
            }
            return visible;
        }

        public static int Two(List<List<int>> input)
        {
            int NumViewed(int i, int j, Func<int, int> newI, Func<int, int> newJ)
            {
                var currI = newI(i);
                var currJ = newJ(j);
                var done = false;
                var score = 0;

                while (!done)
                {
                    if (currI < 0 || currI >= input.Count)
                    {
                        done = true;
                    }
                    else
                    {
                        var row = input[currI];
                        if (currJ < 0 || currJ >= row.Count)  
                        {
                            done = true;
                        }
                        else
                        {
                            score++;
                            if (input[i][j] <= row[currJ])
                            {
                                done = true;
                            }
                        }
                    }
                    currI = newI(currI); 
                    currJ = newJ(currJ);
                }

                return score;
            }

            var maxScore = 0;
            for (var i = 0; i < input.Count; i++)
            {
                for (var j = 0; j < input[i].Count; j++)
                {
                    var score = NumViewed(i, j, i => i + 1, j => j) *
                                NumViewed(i, j, i => i - 1, j => j) *
                                NumViewed(i, j, i => i, j => j + 1) *
                                NumViewed(i, j, i => i, j => j - 1);

                    maxScore = Math.Max(maxScore, score);
                }
            }
            return maxScore;
        }
    }
}

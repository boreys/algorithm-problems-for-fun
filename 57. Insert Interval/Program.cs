int[][] intervals =
{
    new int[]{1, 2},
    new int[]{3, 5},
    new int[]{6, 7},
    new int[]{8, 10},
    new int[]{12, 16},
};

int[] newInterval = { 4, 8 };
string expected = "[[1,2],[3,10],[12,16]]";

Solution sol = new Solution();
var result = sol.Insert(intervals, newInterval);

Console.WriteLine($"Result: {format(result)}, expected: {expected}");

string format(int[][] intervals)
{
    List<string> slist = new List<string>();
    foreach(var item in intervals)
    {
        slist.Add("[" + string.Join(",", item) + "]");
    }
    return "[" + string.Join(",", slist.ToArray()) + "]";   
}

public class Solution
{
    public int[][] Insert(int[][] intervals, int[] newInterval)
    {
        List<int[]> intervalList = new List<int[]>(intervals);
        intervalList.Add(newInterval);

        intervalList.Sort((a, b) => a[0].CompareTo(b[0]));

        List<int[]> mergedIntervals = new List<int[]>();

        int[] prev = intervalList[0];

        for (int i = 1; i < intervalList.Count; i++)
        {
            int[] current = intervalList[i];
            if (prev[1] >= current[0])
            {
                prev[1] = Math.Max(prev[1], current[1]);
            }
            else
            {
                mergedIntervals.Add(prev);
                prev = intervalList[i];
            }
        }

        mergedIntervals.Add(prev);

        return mergedIntervals.ToArray();
    }
}
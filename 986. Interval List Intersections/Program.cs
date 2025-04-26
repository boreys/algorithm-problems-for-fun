int[][] firstList =
{
    new int[]{8, 15}
};

int[][] secondList =
{
    new int[]{2, 6},
    new int[]{8, 10},
    new int[]{12, 20}
};

string expected = "[[8,10],[12,15]]";

//int[][] firstList =
//{
//    new int[]{0, 2},
//    new int[]{5, 10},
//    new int[]{13, 23},
//    new int[]{24, 25}
//};

//int[][] secondList =
//{
//    new int[]{1, 5},
//    new int[]{8, 12},
//    new int[]{15, 24},
//    new int[]{25, 26}
//};

//string expected = "[[1,2],[5,5],[8,10],[15,23],[24,24],[25,25]]";

Solution sol = new Solution();
var result = sol.IntervalIntersection(firstList, secondList);

Console.WriteLine($"Result: {format(result)}, expected: {expected}");

string format(int[][] intervals)
{
    List<string> slist = new List<string>();
    foreach (var item in intervals)
    {
        slist.Add("[" + string.Join(",", item) + "]");
    }
    return "[" + string.Join(",", slist.ToArray()) + "]";
}

public class Solution
{
    public int[][] IntervalIntersection(int[][] firstList, int[][] secondList)
    {
        List<int[]> list = new List<int[]>(firstList);
        list.AddRange(secondList);

        list.Sort((a, b) => a[0].CompareTo(b[0]));

        List<int[]> mergedList = new List<int[]>();

        int[] prev = list[0];

        for(int i = 1; i < list.Count; i++)
        {
            int[] current = list[i];
            if (prev[1] >= current[0])
            {
                int[] item = new int[2];
                item[0] = Math.Max(current[0], prev[0]);
                item[1] = Math.Min(current[1], prev[1]);

                prev[0] = item[1];
                prev[1] = Math.Max(prev[1], current[1]);

                mergedList.Add(item);
            }
            else
            {
                prev = current;
            }
        }

        return mergedList.ToArray();
    }
}
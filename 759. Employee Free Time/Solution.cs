public class Solution {
    public int[][] EmployeeFreeTime(int[][][] schedule) {
        if(schedule == null || schedule.Length < 1) return new int[0][];

        List<int> start = new List<int>();
        List<int> end = new List<int>();
        for(int i=0;i<schedule.Length;i++){
            int[][] one = schedule[i];
            for(int k=0;k<one.Length;k++){
                start.Add(one[k][0]);
                end.Add(one[k][1]);
            }
        }

        start.Sort();
        end.Sort();
        
        List<int[]> result = new List<int[]>();
        int stop = start.Count - 1;
        for(int i=0;i<stop;i++){
            int curEnd = end[i];
            int nextStart = start[i+1];
            if(nextStart > curEnd){
                result.Add(new int[]{curEnd,nextStart});
            }
        }
        return result.ToArray();
    }
}
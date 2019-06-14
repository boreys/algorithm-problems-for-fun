public class Solution {
    public int MinMeetingRooms(int[][] intervals) {
        if(intervals == null || intervals.Length < 1) return 0;
        int size = intervals.Length;
        int[] starts = new int[size];
        int[] ends = new int[size];
        for(int i=0;i<size;i++){
            starts[i] = intervals[i][0];
            ends[i] = intervals[i][1];
        }
        Array.Sort(starts);
        Array.Sort(ends);
        int count = 0;
        int endIndex = 0;
        for(int i=0;i<size;i++){
            count++;
            if(ends[endIndex] <= starts[i]){
                endIndex++;
                count--;
            }
        }
        return count;
    }
}
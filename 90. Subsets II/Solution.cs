public class Solution {
    public IList<IList<int>> SubsetsWithDup(int[] nums) {
        List<IList<int>> result = new List<IList<int>>();
        if(nums == null || nums.Length < 1){
            return result;
        }
        Array.Sort(nums);
        SubsetsWithDup(nums,result, new List<int>(), 0);
        return result;
    }
    void SubsetsWithDup(int[] nums,List<IList<int>> result, List<int> chosen, int start){
        result.Add(new List<int>(chosen));
        for(int i=start;i<nums.Length;i++){
            int n = nums[i];
            if(i > start && n == nums[i-1]){
                continue;
            }
            chosen.Add(n);
            
            SubsetsWithDup(nums, result, chosen, i+1);
            
            chosen.RemoveAt(chosen.Count -1);
            
        }
    }
    
}
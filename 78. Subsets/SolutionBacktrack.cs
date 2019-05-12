public class SolutionBacktrack {
    public IList<IList<int>> Subsets(int[] nums) {
        List<IList<int>> result = new List<IList<int>>();
        if(nums == null || nums.Length < 1){
            return result;
        }
        SubsetsHelper(nums, result, new List<int>(), 0);
        return result;
    }
    void SubsetsHelper(int[] nums, List<IList<int>> result, List<int> chosen, int start){
        
        result.Add(new List<int>(chosen));
        for(int i=start;i<nums.Length;i++){
            //choose
            chosen.Add(nums[i]);
            
            //explore
            SubsetsHelper(nums, result, chosen, i+1);
            
            //un-choose
            chosen.RemoveAt(chosen.Count -1);
            
        }
    }
}
public class Solution {
    //runtime: O(n), space complexity: O(n)
    public int FirstMissingPositive(int[] nums) {
        if(nums == null || nums.Length < 1){
            return 1;
        }
        HashSet<int> data = new HashSet<int>();
        foreach(var item in nums){
            data.Add(item);
        }
        int missing = 1;
        for(int i=0;i<nums.Length;i++){
            if(!data.Contains(missing)){
                return missing;
            }
            missing++;
        }
        return missing;
    }
    //runtime: O(nlogn), space complexity: O(1)
    public int FirstMissingPositive2(int[] nums) {
        Array.Sort(nums);
        int missing = 1;
        for(int i=0;i<nums.Length;i++){
            if(nums[i] == missing){
                missing++;
            }
        }
        return missing;
    }
}
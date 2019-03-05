public class Solution {
    //runtime: O(n), space complexity: O(n)
    public int[] TwoSum(int[] nums, int target) {
        int[] result = new int[2];
        Dictionary<int,int> dict = new Dictionary<int,int>();
        for(int i=0;i<nums.Length;i++){
            dict[nums[i]] = i;
        }
        int diff;
        for(int i=0;i<nums.Length;i++){
            diff = target - nums[i];
            if(dict.ContainsKey(diff) && dict[diff] != i){
                result[0] = i;
                result[1] = dict[diff];
                break;
            }
        }
        return result;
    }
    //runtime: O(n^2), space complexity: O(1)
    public int[] TwoSumSlow(int[] nums, int target) {
        int[] result = new int[2];
        for(int i=0;i<nums.Length;i++){
            for(int k=i+1;k<nums.Length;k++){
                if(nums[i] + nums[k] == target){
                    result[0] = i;
                    result[1] = k;
                    break;
                }
            }
        }
        return result;
    }
    
}
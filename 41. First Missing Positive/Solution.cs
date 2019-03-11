public class Solution {
    //runtime: O(n), space complexity: O(1)
    public int FirstMissingPositive(int[] nums) {
        if(nums == null || nums.Length < 1){
            return 1;
        }
        int n = nums.Length;
        bool shouldKeepSwapping = false;
        for(int i=0;i<n;i++){
            shouldKeepSwapping = true;
            while (shouldKeepSwapping && nums[i] > 0 && nums[i] < n)
            {
                int pos = nums[i] - 1;
                if(pos != i && nums[i] != nums[pos])
                {
                    swap(nums, pos, i);
                    shouldKeepSwapping = (nums[i] > 0 && nums[i] != pos);
                }
                else
                {
                    shouldKeepSwapping = false;
                }
            }
        }
        int missing = 1;
        for(int i=0;i<nums.Length;i++){
            if(nums[i] != missing){
                return missing;
            }
            missing++;
        }
        return missing;
    }
    void swap(int[] A, int i, int j){
        int tmp = A[i];
        A[i] = A[j];
        A[j] = tmp;
    }
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
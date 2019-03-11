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
    //runtime: O(n), space complexity: O(1)
    public int MissingNumber(int[] nums) {
        if(nums == null || nums.Length < 1){
            return 0;
        }
        int min = nums.Length;
        int max = -1;
        int totalNum = 0;
        int sumArrayIndex = 0;
        for(int i=0;i<nums.Length;i++){
            if(nums[i] < min){
                min = nums[i];
            }else if(nums[i] > max){
                max = nums[i];
            }
            totalNum += nums[i];
            sumArrayIndex += i;
        }
        sumArrayIndex += nums.Length;
        
        if(min != 0){
            return 0;
        }
        if(max != nums.Length){
            return nums.Length;
        }
        return sumArrayIndex - totalNum;
    }
    //runtime: O(n), space complexity: O(n)
    public int MissingNumber2(int[] nums) {
        if(nums == null || nums.Length < 1){
            return 0;
        }
        int min = nums.Length;
        int max = -1;
        HashSet<int> bag = new HashSet<int>();
        foreach(var n in nums){
            bag.Add(n);
            if(n > max){
                max = n;
            }
            if(n < min){
                min = n;
            }
        }
        if(min !=0){
            return 0;
        }
        if(max != nums.Length){
            return nums.Length;
        }
        int missing = -1;
        foreach(var n in nums){
            int next = n + 1;
            if(!bag.Contains(next) && next < max){
                missing = next;
            }
        }
        return missing;
    }
}
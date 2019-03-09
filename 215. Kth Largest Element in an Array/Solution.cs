public class Solution {
    //runtime: O(nlogn), space complexity: O(1)
    public int FindKthLargest(int[] nums, int k) {
        Array.Sort(nums);
        return nums[nums.Length - k];
    }
}
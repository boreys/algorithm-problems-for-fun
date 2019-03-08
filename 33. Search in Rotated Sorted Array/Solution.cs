public class Solution {
    public int Search(int[] nums, int target) {
        if(nums == null || nums.Length < 1){
            return -1;
        }
        
        int start = findMinIndex(nums);
        int stop = nums.Length;
        if(start > 0 && target > nums[stop-1]){
            return findTarget(nums, 0, start, target);
        }
        return findTarget(nums, start, stop,target);
        
    }
    int findMinIndex(int[] nums){
        int start = 0, stop = nums.Length - 1;
        int mid;
        while(start < stop){
            mid = (stop - start)/2 + start;
            if(nums[mid] > nums[stop]){
                start = mid + 1;
            }else{
                stop = mid;
            }
        }
        return start;
    }
    int findTarget(int[] nums, int start, int stop, int target){
        int mid;
        while(start < stop){
            mid = (stop - start) / 2 + start;
            if(nums[mid] < target){
                start = mid + 1;
            }else if(nums[mid] > target){
                stop = mid;
            }else{
                return mid;
            }
        }
        return -1;
    }
}
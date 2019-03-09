public class Solution {
    //runtime: O(xlogx) where x = m + n
    public void Merge(int[] nums1, int m, int[] nums2, int n) {
        int j=0;
        for(int i=m;i<nums1.Length;i++){
            nums1[i] = nums2[j++];
        }
        Array.Sort(nums1);
    }
}
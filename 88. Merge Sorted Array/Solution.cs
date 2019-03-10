public class Solution {
    //runtime: O(m+n), space complexity: O(1)
    public void Merge(int[] nums1, int m, int[] nums2, int n) {
        int i = m - 1;
        int k = n - 1;
        int end = nums1.Length - 1;
        int oneVal, twoVal;
        while(i >= 0 && k >= 0){
            oneVal = nums1[i];
            twoVal = nums2[k];
            if(oneVal > twoVal){
                nums1[end--] = nums1[i--];
            }else if(oneVal < twoVal){
                nums1[end--] = nums2[k--];
            }else{
                nums1[end--] = nums1[i--];
                nums1[end--] = nums2[k--];
            }
        }
        while(k>=0){
            nums1[end--] = nums2[k--];
        }
    }
    //runtime: O(xlogx) where x = m + n
    public void Merge2(int[] nums1, int m, int[] nums2, int n) {
        int j=0;
        for(int i=m;i<nums1.Length;i++){
            nums1[i] = nums2[j++];
        }
        Array.Sort(nums1);
    }
}
public class SolutionSlow {
    //runtime: O(m/2 + n/2), space complexity: O(1)
    public double FindMedianSortedArrays(int[] nums1, int[] nums2) {
        int size1 = nums1.Length;
        int size2 = nums2.Length;
        int size = size1 + size2;
        int midStart = size / 2;
        int midStop = midStart;
        if(size % 2 == 0){
            midStart--;
        }
        int i =0;
        int j = 0;
        int count = 0;
        int take = 0;
        double mid1 = 0;
        double mid2 = 0;
        while(i < size1 || j < size2){
            if(i < size1 && j < size2){
                if(nums1[i] < nums2[j]){
                    take = nums1[i++];
                }else{
                    take = nums2[j++];
                }   
            }else if(i < size1){
                take = nums1[i++];
            }else if(j < size2){
                take = nums2[j++];
            }
            
            if(count == midStart){
                mid1 = (double)take;
            }
            if(count == midStop){
                mid2 = (double)take;
                break;
            }
            count++;
        }
        return (mid1 + mid2) / 2;
    }
}
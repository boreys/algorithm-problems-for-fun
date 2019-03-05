public class Solution {
    public IList<IList<int>> Subsets(int[] nums) {
        IList<IList<int>> list = new List<IList<int>>();
        if(nums == null || nums.Length < 0){
            return list;
        }
        list.Add(new int[0]);
        for(int i =0;i<nums.Length;i++){
            int size = list.Count;
            for(int k=0;k<size;k++){
                List<int> sub = new List<int>(list[k]);
                sub.Add(nums[i]);
                list.Add(sub);
            }
        }
        return list;
    }
}
public class Solution {
    public IList<IList<int>> Permute(int[] nums) {
        List<IList<int>> result = new List<IList<int>>();
        if(nums == null || nums.Length < 1){
            return result;
        }
        List<int> numList = new List<int>(nums);
        PermuteHelper(numList, result, new List<int>());
        return result;
    }
    void PermuteHelper(List<int> list, List<IList<int>> result, List<int> chosen){
        if(list.Count == 0){
            result.Add(new List<int>(chosen));
        }else{
            for(int i = 0; i < list.Count; i++)
            {
                //choose
                int n = list[i];
                list.RemoveAt(i);
                chosen.Add(n);

                //explore
                PermuteHelper(list, result, chosen);

                //un-choose
                chosen.RemoveAt(chosen.Count - 1);
                list.Insert(i, n);
            }
        }
    }
}
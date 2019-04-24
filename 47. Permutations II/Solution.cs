public class Solution {
    public IList<IList<int>> PermuteUnique(int[] nums) {
        List<IList<int>> result = new List<IList<int>>();
        if(nums == null || nums.Length < 1){
            return result;
        }
        Array.Sort(nums);
        List<int> list = new List<int>(nums);
        List<int> chosen = new List<int>();
        PermuteHelper(list, result, chosen);
        return result;
    }
    void PermuteHelper(List<int> list, List<IList<int>> result, List<int> chosen){
        if(list.Count == 0){
            result.Add(new List<int>(chosen));
        }else{
            for(int i=0;i<list.Count;i++){
                //choose
                int n = list[i];
                if(i > 0 && list[i-1] == n){
                    continue;
                }
                
                chosen.Add(n);
                list.RemoveAt(i);
                
                //explore
                PermuteHelper(list, result, chosen);
                
                //un-choose
                chosen.RemoveAt(chosen.Count-1);
                list.Insert(i, n);
            }
        }
    }
}
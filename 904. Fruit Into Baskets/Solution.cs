public class Solution {
    public int TotalFruit(int[] tree) {
        if(tree == null || tree.Length < 1){
            return 0;
        }
        int max = 0;
        int posA = -1;
        int valA = Int32.MinValue;
        int posB = -1;
        int valB = Int32.MinValue;
        int end = tree.Length;
        int i = 0;
        int total = 0;
        int n = Int32.MinValue;
        while(i < end){
            total++;
            n = tree[i];
            if(posA == -1 || n == valA){
                posA = i;
                valA = n;
            }else if(posB == -1 || n == valB){
                posB = i;
                valB = n;
            }else{
                max = Math.Max(max, total - 1);
                total = Math.Abs(posA - posB) + 1;
                posA = i -1;
                valA = tree[i-1];
                posB = i;
                valB = n;
            }
            i++;
        }
        max = Math.Max(max, total);
        return max;
    }
    
}
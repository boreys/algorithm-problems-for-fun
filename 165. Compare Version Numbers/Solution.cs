public class Solution {
    public int CompareVersion(string version1, string version2) {
        string[] v1 = version1.Split('.');
        string[] v2 = version2.Split('.');
        int size = Math.Max(v1.Length,v2.Length);
        int[] arrv1 = new int[size];
        int[] arrv2 = new int[size];
        for(int i=0;i<v1.Length;i++){
            int n = Convert.ToInt32(v1[i]);
            arrv1[i] = n;
        }
        for(int i=0;i<v2.Length;i++){
            int n = Convert.ToInt32(v2[i]);
            arrv2[i] = n;
        }
        for(int i=0;i<arrv1.Length;i++){
            int n1 = arrv1[i];
            int n2 = arrv2[i];
            if(n1 < n2){
                return -1;
            }else if(n1 > n2){
                return 1;
            }
        }
        return 0;
    }
}
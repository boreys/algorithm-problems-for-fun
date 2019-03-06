public class Solution {
    //runtime: O(n), space complexity: O(n)
    public int LengthOfLongestSubstring(string s) {
        if(string.IsNullOrEmpty(s)){ return 0;}
        if(s.Length == 1){ return 1; }
        
        int len = s.Length;
        int max = 1;
        int start = 0, stop = 1;
        Dictionary<char,int> index = new Dictionary<char,int>();
        index[s[0]] = 0;
        
        while(stop < len){
            char ch = s[stop];
            if(!index.ContainsKey(ch)){
                int n = stop - start + 1;
                if(n > max){
                    max = n;
                }
            }else{
                //remove data in index up to the next starting point
                int newIndex = index[ch] + 1;
                for(int i=start;i<newIndex;i++){
                    index.Remove(s[i]);
                }
                start = newIndex;
            }
            index[ch] = stop;
            stop++;
        }
        return max;
    }

    //runtime: O(n^2), space complexity: O(1)
    public int LengthOfLongestSubstringSlow(string s) {
        if(string.IsNullOrEmpty(s)){ return 0;}
        if(s.Length == 1){ return 1; }

        int start = 0, stop = 1, max = 1, foundPos = -1, n = 0;
        char target;
        while(stop < s.Length){
            target = s[stop];
            foundPos = found(s, start, stop, target);
            if (foundPos > -1){
                start = foundPos + 1;
            }else{
                n = stop - start + 1;
                if (n > max)
                {
                    max = n;
                }
            }
            stop++;
        }
        return max;
    }
    int found(string s, int start, int stop, char ch){
        for (int i = start; i < stop;i++){
            if(s[i] == ch){
                return i;
            }
        }
        return -1;
    }
}
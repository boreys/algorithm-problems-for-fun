public class Solution {
    //runtime: O(n), memory: O(n)
    public bool IsAnagram(string s, string t) {
        if(string.IsNullOrEmpty(s) && string.IsNullOrEmpty(t)){
            return true;
        }
        if(s.Length != t.Length){
            return false;
        }
        Dictionary<char,int> data = new Dictionary<char,int>();
        foreach(char ch in s){
            if(data.ContainsKey(ch)){
               data[ch] = data[ch] + 1; 
            }else{
                data[ch] = 1;
            }
        }
        foreach(char ch in t){
            if(!data.ContainsKey(ch)){
                return false;
            }
            int count = data[ch];
            if(count == 1){
                data.Remove(ch);
            }else{
                data[ch] = count -1;
            }
        }
        return data.Count == 0;
    }
    //runtime: O(nlogn), memory: O(n)
    public bool IsAnagram2(string s, string t) {
        if(string.IsNullOrEmpty(s) && string.IsNullOrEmpty(t)){
            return true;
        }
        if(s.Length != t.Length){
            return false;
        }
        int sIndex = 0, tIndex = 0;
        int ssize = s.Length;
        int tsize = t.Length;
        char[] sarr = s.ToCharArray();
        Array.Sort(sarr);
        char[] tarr = t.ToCharArray();
        Array.Sort(tarr);
        while(sIndex < ssize && tIndex < tsize){
            if(sarr[sIndex] != tarr[tIndex]){
                return false;
            }
            sIndex++;
            tIndex++;
        }
        
        return true;
    }
}
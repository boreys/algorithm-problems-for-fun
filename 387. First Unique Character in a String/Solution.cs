public class Solution {
    //runtime: O(n), space complexity: O(n)
    public int FirstUniqChar(string s) {
        Dictionary<char, int> data = new Dictionary<char,int>();
        foreach(char ch in s){
            if(!data.ContainsKey(ch)){
                data[ch] = 1;
            }else{
                int count = data[ch];
                data[ch] = count + 1;
            }
        }
        for(int i=0;i<s.Length;i++){
            if(data[s[i]] == 1){
                return i;
            }
        }
        return -1;
    }
}
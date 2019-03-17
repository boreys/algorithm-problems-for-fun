public class Solution {
    //runtime: O(n), space complexity: O(n)
    public string ReverseWords(string s) {
        if(string.IsNullOrEmpty(s)){
            return s;
        }
        string[] words = s.Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries);
        int start = 0;
        int end = words.Length - 1;
        while(start < end){
            string tmp = words[start];
            words[start] = words[end];
            words[end] = tmp;
            start++;
            end--;
        }
        return String.Join(" ", words);
    }
}
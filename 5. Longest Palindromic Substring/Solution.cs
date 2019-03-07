public class Solution {
    public string LongestPalindrome(string s) {
        if(string.IsNullOrEmpty(s) || s.Length == 1){
            return s;
        }
        int max = 1;
        int startIndex = 0;
        for (int i = 0; i < s.Length - 1; i++)
        {
            var result = findIt(s, i, i + 1, max);
            if(result.length > max){
                startIndex = result.start;
                max = result.length;
            }
            result = findIt(s, i, i, max);
            if (result.length > max)
            {
                startIndex = result.start;
                max = result.length;
            }
        }
        return s.Substring(startIndex, max);
    }
    public (int start, int length) findIt(string s, int prev, int next, int max){
        int startIndex = prev;
        int maxLen = max;
        while (prev >= 0 && next < s.Length && s[prev] == s[next])
        {
            if ((next - prev + 1) > maxLen)
            {
                maxLen = next - prev + 1;
                startIndex = prev;
            }
            prev--;
            next++;
        }
        return (start: startIndex, maxLen);
    }
}
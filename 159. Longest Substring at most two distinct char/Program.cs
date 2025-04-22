string s = "ccaabbb";
int expected = 5;

Solution sol = new Solution();

var result = sol.lengthOfLongestSubstringTwoDistinct(s);

Console.WriteLine($"Result: {result}, expected: {expected}");


class Solution
{
    public int lengthOfLongestSubstringTwoDistinct(string s)
    {
        int maxLen = 0;
        int counter = 0;
        int start = 0;
        int end = 0;
        Dictionary<char, int> index = new Dictionary<char, int>();
        foreach(var ch in s)
        {
            if (!index.ContainsKey(ch))
            {
                index.Add(ch, 0);
            }
        }

        while(end < s.Length)
        {
            char currentChar = s[end];
            if (index[currentChar] == 0)
            {
                counter += 1;
            }

            index[currentChar] += 1;
            end += 1;

            while(counter > 2)
            {
                char ch = s[start];
                index[ch] -= 1;
                if (index[ch] == 0)
                {
                    counter -= 1;
                }
                start += 1;
            }

            int len = end - start;
            if(len > maxLen)
            {
                maxLen = len;
                string sub = s.Substring(start, len);
                Console.WriteLine(sub);
            }
        }

        return maxLen;
    }
}
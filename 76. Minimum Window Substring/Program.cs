Solution sol = new Solution();

string s = "HADOBECODEBANC";
string t = "ABC";
string expected = "BANC";

var result = sol.MinWindow(s, t);

Console.WriteLine($"Result: {result}, expected: {expected}");

public class Solution
{
    public string MinWindow(string s, string t)
    {
        int[] map = new int[128];
        foreach (char c in t) map[c]++;

        int counter = t.Length, begin = 0, end = 0, minLen = int.MaxValue, minStart = 0;

        while (end < s.Length)
        {
            char currentChar = s[end];
            
            if (map[currentChar] > 0)
            {
                counter--; // in t
            }

            map[currentChar] -= 1;

            end++;

            while (counter == 0)
            {
                int subLen = end - begin;
                if (subLen < minLen)
                {
                    minLen = subLen;
                    minStart = begin;
                }

                char startChar = s[begin];
                if (map[startChar] == 0)
                {
                    counter++;
                }

                map[startChar]++;

                begin++;
            }
        }

        return minLen == int.MaxValue ? "" : s.Substring(minStart, minLen);
    }

    public string MinWindowSlow(string s, string t)
    {
        string result = "";
        int minLen = s.Length + 1;
        int start = 0;

        Dictionary<char, int> index = new Dictionary<char, int>();

        // set counter for all char from t
        foreach(var ch in t)
        {
            if (index.ContainsKey(ch))
            {
                index[ch] += 1;
            }
            else
            {
                index.Add(ch, 1);
            }
        }

        int counter = t.Length;

        for(int i = 0; i < s.Length; i++)
        {
            char currentChar = s[i];
            if (index.ContainsKey(currentChar))
            {
                if(index[currentChar] > 0)
                {
                    counter -= 1;
                }
                //counter in index can go nagative when there are more char in s than t
                index[currentChar] -= 1;
            }

            while (counter == 0)
            {
                int len = i - start + 1;

                if(minLen > len)
                {
                    minLen = len;
                    result = s.Substring(start, len);
                    Console.WriteLine(result);
                }
                char startChar = s[start];
                if (index.ContainsKey(startChar))
                {
                    int startCounter = index[startChar] + 1;
                    index[startChar] = startCounter;
                    if (startCounter > 0)
                    {
                        counter += 1;
                    }
                }

                start += 1;

            }
        }

        return result;
    }
    
}
public class Solution {
    public string MinWindow(string s, string t) {
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
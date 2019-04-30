public class Solution {
    public IList<string> GenerateParenthesis(int n) {
        List<string> ptlist = new List<string>();
        ParenthesisHelper(ptlist, new List<char>(), 0, 0, n);
        return ptlist;
    }
    void ParenthesisHelper(List<string> list, List<char> chosen, int open, int close, int max)
    {
        if (chosen.Count == max * 2)
        {
            list.Add(new String(chosen.ToArray()));
            return;
        }
        if (open < max)
        {
            //choose
            chosen.Add('(');

            //explore
            ParenthesisHelper(list, chosen, open + 1, close, max);

            //un-choose
            chosen.RemoveAt(chosen.Count - 1);
        }
        if (close < open)
        {
            //choose
            chosen.Add(')');

            //explore
            ParenthesisHelper(list, chosen, open, close + 1, max);

            //un-choose
            chosen.RemoveAt(chosen.Count - 1);
        }
    }
}
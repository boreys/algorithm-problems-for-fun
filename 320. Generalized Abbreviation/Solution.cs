public class Solution {
    public IList<string> GenerateAbbreviations(string word) {
        List<string> result = new List<string>();
        Generate(word, result, "", 0);
        return result;
    }
    void Generate(string words, List<string> result, string chosen, int n){
        if(words.Length == n){
            result.Add(chosen);
            return;
        }
        //choose
        char ch = words[n];

        //explore
        Generate(words, result, chosen, n+1);
        Generate(words, result, chosen, n + 1);

        //un-choose
        words.InsertAt(0, ch);
    }
}
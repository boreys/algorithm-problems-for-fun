public class Solution {
    public IList<string> LetterCombinations(string digits) {
        List<string> result = new List<string>();
        if(string.IsNullOrEmpty(digits)){
            return result;
        }
        List<List<char>> charlist = new List<List<char>>();
        var dict = GetData();
        foreach(var ch in digits){
            charlist.Add(new List<char>(dict[ch]));
        }
        GetResult(charlist, result, "", digits.Length, 0);
        return result;
    }
    void GetResult(List<List<char>> list, List<string> result, string chosen, int size, int startlist){
        if(chosen.Length == size){
            result.Add(chosen);
        }else if(startlist < list.Count){
            List<char> sublist = list[startlist];
            for(int i=0;i<sublist.Count;i++){
                GetResult(list, result, chosen + sublist[i], size, startlist + 1);
            }
        }
    }
    public Dictionary<char,char[]> GetData(){
        Dictionary<char,char[]> data = new Dictionary<char,char[]>();
        data['1'] = new char[]{'*'};
        data['2'] = new char[]{'a','b','c'};
        data['3'] = new char[]{'d','e','f'};
        data['4'] = new char[]{'g','h','i'};
        data['5'] = new char[]{'j','k','l'};
        data['6'] = new char[]{'m','n','o'};
        data['7'] = new char[]{'p','q','r','s'};
        data['8'] = new char[]{'t','u','v'};
        data['9'] = new char[]{'w','x','y','z'};
        data['0'] = new char[]{' '};
        return data;
    }
}
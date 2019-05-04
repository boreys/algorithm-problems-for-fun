public class Solution {
    public IList<string> LetterCombinations(string digits) {
        IList<string> result = new List<string>();
        if(string.IsNullOrEmpty(digits)){
            return result;
        }
        Dictionary<char,char[]> data = GetData();
        Queue<string> working = new Queue<string>();
        Queue<string> output = new Queue<string>();
        for(int i=0;i<digits.Length;i++){
            if(data.ContainsKey(digits[i])){
                char[] arr = data[digits[i]];
                if(working.Count < 1){
                    foreach(char ch in arr){
                        working.Enqueue(ch.ToString());
                    }
                }else{
                    while(working.Count > 0){
                        string str = working.Dequeue();
                        foreach(char ch in arr){
                            output.Enqueue(str+ch.ToString());
                        }
                    }
                    Queue<string> tmp = output;
                    output = working;
                    working = tmp;
                }
            }
        }
        return working.ToArray();
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
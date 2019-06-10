public class Solution {
    public string AlienOrder(string[] words) {
        if(words == null || words.Length < 1){
            return "";
        }
        Dictionary<char,int> indegree = new Dictionary<char,int>();
        foreach(var word in words){
            foreach(char ch in word){
                if(!indegree.ContainsKey(ch)){
                    indegree.Add(ch, 0);
                }
            }
        }
        Dictionary<char,List<char>> graph = new Dictionary<char,List<char>>();
        for(int i=0;i<words.Length -1;i++){
            string cword = words[i];
            string nword = words[i+1];
            int size = Math.Min(cword.Length,nword.Length);
            for(int k=0;k<size;k++){
                if(cword[k] != nword[k]){
                    char currentChar = cword[k];
                    char nextChar = nword[k];
                    if(!graph.ContainsKey(currentChar)){
                        graph[currentChar] = new List<char>();
                    }
                    List<char> list = graph[currentChar];
                    list.Add(nextChar);
                    graph[currentChar] = list;
                    indegree[nextChar] = indegree[nextChar]+1;
                    break;
                }
            }
        }
        Queue<char> que = new Queue<char>();
        foreach(var kv in indegree){
            if(kv.Value == 0){
                que.Enqueue(kv.Key);
            }
        }
        string result = "";
        while(que.Count > 0){
            char item = que.Dequeue();
            result += item;
            if(graph.ContainsKey(item)){
                List<char> list = graph[item];
                foreach(var ch in list){
                    int n = indegree[ch]-1;
                    indegree[ch] = n;
                    if(n == 0){
                        que.Enqueue(ch);
                    }
                }   
            }
        }
        if(result.Length != indegree.Count){
            return "";
        }
        return result;
    }
}
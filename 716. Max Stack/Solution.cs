public class MaxStack {

    List<int> list;
    int maxIndex;
    int maxValue;
    public MaxStack() {
        list = new List<int>();
        maxValue = Int32.MinValue;
    }
    
    public void Push(int x) {
        list.Add(x);
        if(x >= maxValue){
            maxValue = x;
            maxIndex = list.Count -1;
        }
    }
    
    public int Pop() {
        int x = list[list.Count -1];
        list.RemoveAt(list.Count-1);
        if(x == maxValue){
            findNewMax();
        }
        return x;
    }
    
    public int Top() {
        return list[list.Count -1];
    }
    
    public int PeekMax() {
        return list[maxIndex];
    }
    
    public int PopMax() {
        int x = maxValue;
        list.RemoveAt(maxIndex);
        findNewMax();
        return x;
    }
    void findNewMax(){
        maxValue = Int32.MinValue;
        for(int i=0;i<list.Count;i++){
            if(list[i] >= maxValue){
                maxValue = list[i];
                maxIndex = i;
            }
        }
    }
}

/**
 * Your MaxStack object will be instantiated and called as such:
 * MaxStack obj = new MaxStack();
 * obj.Push(x);
 * int param_2 = obj.Pop();
 * int param_3 = obj.Top();
 * int param_4 = obj.PeekMax();
 * int param_5 = obj.PopMax();
 */
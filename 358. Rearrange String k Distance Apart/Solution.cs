public class Solution {
    public string RearrangeString(string s, int k) {
        if(string.IsNullOrEmpty(s)) return "";
        
        Dictionary<char,int> table = new Dictionary<char,int>();
        foreach(var ch in s){
            if(table.ContainsKey(ch)){
                table[ch] = table[ch] + 1;
            }else{
                table[ch] = 1;
            }
        }
        
        PriorityQueue<Bag> minQue = new PriorityQueue<Bag>();
        foreach(var kv in table){
            minQue.Add(new Bag(kv.Key, kv.Value));
        }
        
        List<char> result = new List<char>();
        List<Bag> tmp = new List<Bag>();
        
        while(minQue.Count > 0){
            Bag item = minQue.Poll();
            result.Add(item.Data);
            item.Count--;
            tmp.Add(item);
            
            if(tmp.Count < k) continue;
            
            Bag a = tmp[0];
            tmp.RemoveAt(0);
            if(a.Count > 0){
                minQue.Add(a);
            }
        }
        if(result.Count != s.Length) return "";
        return new string(result.ToArray());
    }
}
class Bag : IComparable
{
    public int Count;
    public char Data;
    public int CompareTo(object obj)
    {
        Bag b = (Bag)obj;
        return b.Count.CompareTo(this.Count);
    }
    public Bag(char ch, int count)
    {
        Count = count;
        Data = ch;
    }
}
class PriorityQueue<T> where T : IComparable
{
    List<T> list = null;
    Func<T, T, int> _comparer = null;
    public PriorityQueue(Func<T, T, int> comparer = null)
    {
        this.list = new List<T>();
        _comparer = comparer;
    }
    private int compareTo(T a, T b)
    {
        if(_comparer == null)
        {
            return a.CompareTo(b);
        }
        return _comparer(a, b);
    }
    public void Add(T number)
    {
        this.list.Add(number);
        int count = this.list.Count;
        heapifyUp();
    }
    public T Poll()
    {
        int last = list.Count - 1;
        T result = list[0];
        list[0] = list[last];
        list.RemoveAt(last);
        heapifyDown();
        return result;
    }
    public T Peek()
    {
        return this.list[0];
    }
    public List<T> List {
        get
        {
            return this.list;
        }
    }
    int LeftChildIndex(int parentIndex)
    {
        return 2 * parentIndex + 1;
    }
    int RightChildIndex(int parentIndex)
    {
        return 2 * parentIndex + 2;
    }
    int ParentIndex(int childIndex)
    {
        return (childIndex - 1) / 2;
    }
    public int Count
    {
        get
        {
            return list.Count;
        }
    }
    void heapifyUp()
    {
        int index = this.list.Count - 1;
        int parent = ParentIndex(index);
        int count = this.list.Count;
        while(parent >=0 && compareTo(this.list[parent],this.list[index]) > 0)
        {
            swap(index, parent);
            index = parent;
            parent = ParentIndex(index);
        }
    }
    void swap(int i, int j)
    {
        T tmp = this.list[i];
        this.list[i] = this.list[j];
        this.list[j] = tmp;
    }
    void heapifyDown()
    {
        int size = list.Count;
        int parent = 0;
        int child = LeftChildIndex(parent);
        int rightChild;
        while(child < size)
        {
            rightChild = RightChildIndex(parent);
            if(rightChild < size && compareTo(list[rightChild],list[child]) < 0)
            {
                child = rightChild;
            }
            if(compareTo(list[parent],list[child]) < 0)
            {
                break;
            }
            swap(parent, child);
            parent = child;
            child = LeftChildIndex(parent);
        }
    }
}
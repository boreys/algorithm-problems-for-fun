public class Solution {
    public IList<int> TopKFrequent(int[] nums, int k) {
        List<int> result = new List<int>();
        PriorityQueue<Data> que = new PriorityQueue<Data>((a,b)=> b.Count.CompareTo(a.Count));
        Dictionary<int,int> dict = new Dictionary<int,int>();
        int len = nums.Length;
        int n;
        for(int i=0;i<len;i++){
            n = nums[i];
            if(dict.ContainsKey(n)){
                dict[n] = dict[n]+1;
            }else{
                dict[n] = 1;
            }
        }
        foreach(var kv in dict){
            que.Add(new Data(kv.Key, kv.Value));
        }
        for(int i = 0;i<k && que.Count > 0;i++){
            result.Add(que.Poll().Value);
        }
        return result;
    }
}
class Data: IComparable{
    public int Value{get;set;}
    public int Count{get;set;}
    public Data(int value, int count){
        this.Value = value;
        this.Count = count;
    }
    public int CompareTo(object obj) {
        Data b = (Data)obj;
        return this.Count.CompareTo(b.Count);
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
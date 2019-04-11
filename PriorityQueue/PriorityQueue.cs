class PriorityQueue<T> where T : IComparable
{
    List<T> list = null;
    public PriorityQueue()
    {
        this.list = new List<T>();
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
        while(parent >=0 && this.list[parent].CompareTo(this.list[index]) > 0)
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
            if(rightChild < size && list[rightChild].CompareTo(list[child]) < 0)
            {
                child = rightChild;
            }
            if(list[parent].CompareTo(list[child]) < 0)
            {
                break;
            }
            swap(parent, child);
            parent = child;
            child = LeftChildIndex(parent);
        }
    }
}
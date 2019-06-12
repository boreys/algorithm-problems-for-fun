# Implementing Priority Queue or Heap in C#
There is no PriorityQueue or Heap data structure in dotnet Framework or Core. It is a very useful class to solve some hard algorithm problem. So, here is my implementation for the world to use. 

**Example:**
```
class MainClass
{
    public static void Main(string[] args)
    {
        PriorityQueue<int> minHeap = new PriorityQueue<int>();
        minHeap.Add(4);
        minHeap.Add(25);
        minHeap.Add(2);
        minHeap.Add(1);

        while(minHeap.Count > 0)
        {
            var item = minHeap.Poll();
            Console.Write($"{item}->");
        }
        Console.WriteLine();

        PriorityQueue<int> maxHeap = new PriorityQueue<int>((int a, int b) => b.CompareTo(a));
        maxHeap.Add(500);
        maxHeap.Add(100);
        maxHeap.Add(200);
        maxHeap.Add(50);

        while(maxHeap.Count > 0)
        {
            var item = maxHeap.Poll();
            Console.Write($"{item}->");
        }
        Console.WriteLine();
    }
}
```
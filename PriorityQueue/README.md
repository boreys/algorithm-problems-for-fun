# Implementing Priority Queue in C#
There is no PriorityQueue in dotnet Framework or Core. It is a very useful class to solve some hard algorithm problem. So, here is my implementation for the world to use.

**Example:**
```
public static void Main(string[] args)
{
    PriorityQueue<int> que = new PriorityQueue<int>();
    que.Add(4);
    que.Add(25);
    Console.WriteLine($"Peek: {que.Peek()}, Count: {que.Count}");

    List<int> arr = que.List;

    foreach (var item in arr)
    {
        Console.Write($"{item}->");
    }
    que.Poll();
    que.Poll();
    Console.WriteLine();
    Console.WriteLine($"After Poll() twice => Count: {que.Count}");

    Console.WriteLine("Done!");
}
```
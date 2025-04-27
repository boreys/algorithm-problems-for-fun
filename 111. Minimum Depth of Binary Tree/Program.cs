TreeNode root = new TreeNode(1);
root.left = new TreeNode(2);
root.right = new TreeNode(3);
root.left.left = new TreeNode(4);
root.left.right = new TreeNode(5);

string expected = "2";

//TreeNode root = new TreeNode(3);
//root.left = new TreeNode(9);
//root.right = new TreeNode(20);
//root.right.left = new TreeNode(15);
//root.right.right = new TreeNode(7);

//string expected = "2";


Solution sol = new Solution();

var result = sol.MinDepth(root);

Console.WriteLine($"Result: {result}, expected: {expected}");


string format(IList<IList<int>> data)
{
    List<string> list = new List<string>();
    foreach (var item in data)
    {
        list.Add("[" + string.Join(",", item.ToArray()) + "]");
    }
    return "[" + string.Join(",", list.ToArray()) + "]";
}

public class Solution
{
    public int MinDepth(TreeNode root)
    {
        if (root == null) return 0;

        int min = int.MaxValue;

        Queue<TreeNode> queue = new Queue<TreeNode>();
        queue.Enqueue(root);

        int depth = 0;

        while(queue.Count > 0)
        {
            int size = queue.Count;
            depth += 1;

            for(int i = 0; i < size; i++)
            {
                TreeNode node = queue.Dequeue();

                if (node.left == null && node.right == null)
                {
                    min = Math.Min(min, depth);
                }

                if (node.left != null)
                {
                    queue.Enqueue(node.left);
                }

                if (node.right != null)
                {
                    queue.Enqueue(node.right);
                }
            }
        }

        return min;
    }
}

public class TreeNode
{
    public int val;
    public TreeNode left;
    public TreeNode right;
    public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
    {
        this.val = val;
        this.left = left;
        this.right = right;
    }
}
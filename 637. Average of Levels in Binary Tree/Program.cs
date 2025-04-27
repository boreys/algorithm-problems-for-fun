
TreeNode root = new TreeNode(3);
root.left = new TreeNode(9);
root.right = new TreeNode(20);
root.right.left = new TreeNode(15);
root.right.right = new TreeNode(7);

string expected = "[3.00000,14.50000,11.00000]";


Solution sol = new Solution();

var result = sol.AverageOfLevels(root);

Console.WriteLine($"Result: {format(result)}, expected: {expected}");


string format(IList<double> data)
{
    return "[" + string.Join(",", data.ToArray()) + "]";
}

public class Solution
{
    public IList<double> AverageOfLevels(TreeNode root)
    {
        List<double> result = new List<double>();
        if (root == null) return result;

        Queue<TreeNode> queue = new Queue<TreeNode>();
        queue.Enqueue(root);

        while(queue.Count > 0)
        {
            double size = queue.Count;
            double sum = 0;
            for(int i = 0; i < size; i++)
            {
                TreeNode node = queue.Dequeue();
                sum += node.val;
                if (node.left != null) queue.Enqueue(node.left);
                if (node.right != null) queue.Enqueue(node.right);
            }
            result.Add(sum / size);
        }

        return result;
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
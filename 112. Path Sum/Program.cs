TreeNode root = new TreeNode(5);
root.left = new TreeNode(4);
root.right = new TreeNode(8);

root.right.left = new TreeNode(15);
root.right.right = new TreeNode(7);

string expected = "true";
int targetSum = 20;

Solution sol = new Solution();

var result = sol.HasPathSum(root, targetSum);

Console.WriteLine($"Result: {result}, expected: {expected}");


string format(IList<double> data)
{
    return "[" + string.Join(",", data.ToArray()) + "]";
}

public class Solution
{
    public bool HasPathSum(TreeNode root, int targetSum)
    {
        if (root == null) return false;

        if (root.right == null && root.left == null && root.val == targetSum)
        {
            return true;
        }

        int newTarget = targetSum - root.val;
        
        bool leftResult = HasPathSum(root.left, newTarget);
        bool rightResult = HasPathSum(root.right, newTarget);

        return leftResult || rightResult;
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
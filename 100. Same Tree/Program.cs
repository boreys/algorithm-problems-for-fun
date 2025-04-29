using System.Text;

TreeNode root = new TreeNode(1);
root.left = new TreeNode(2);
root.right = new TreeNode(3);

TreeNode root2 = new TreeNode(1);
root2.left = new TreeNode(2);
root2.right = new TreeNode(2);

string expected = "false";

//TreeNode root = new TreeNode(1);
//root.left = new TreeNode(2);
//root.left.left = new TreeNode(3);

//TreeNode root2 = new TreeNode(1);
//root2.right = new TreeNode(2);
//root2.right.right = new TreeNode(3);

//string expected = "true";

Console.WriteLine("Tree 1\n");
TreePrinter.Print(root);

Console.WriteLine("Tree 2\n");
TreePrinter.Print(root2);


Solution sol = new Solution();

var result = sol.IsSameTree(root, root2);

Console.WriteLine($"Result: {result}, expected: {expected}");


string format(IList<double> data)
{
    return "[" + string.Join(",", data.ToArray()) + "]";
}

public class Solution
{
    public bool IsSameTree(TreeNode rootOne, TreeNode rootTwo)
    {
        if (rootOne == null && rootTwo == null) return true;

        if (rootOne == null && rootTwo != null) return false;
        if (rootOne != null && rootTwo == null) return false;

        if (rootOne.val != rootTwo.val) return false;

        if (rootOne.left == null && rootTwo.left != null) return false;
        if (rootOne.left != null && rootTwo.left == null) return false;

        if (rootOne.right == null && rootTwo.right != null) return false;
        if (rootOne.right != null && rootTwo.right == null) return false;

        return IsSameTree(rootOne.left, rootTwo.left) && IsSameTree(rootOne.right, rootTwo.right);
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

using System.Text;

TreeNode root = new TreeNode(1000000000);
root.left = new TreeNode(1000000000);
root.left.left = new TreeNode(294967296);
root.left.left.left = new TreeNode(1000000000);
root.left.left.left.left = new TreeNode(1000000000);
root.left.left.left.left.left = new TreeNode(1000000000);

string expected = "0";
int targetSum = 0;

//TreeNode root = new TreeNode(10);
//root.left = new TreeNode(5);
//root.right = new TreeNode(-3);

////children of 5
//root.left.left = new TreeNode(3);
//root.left.right = new TreeNode(2);
//root.right.right = new TreeNode(11);

////children of 3
//root.left.left.left = new TreeNode(3);
//root.left.left.right = new TreeNode(-2);

////children of 2
//root.left.right.right = new TreeNode(1);

//string expected = "3";
//int targetSum = 8;

Solution sol = new Solution();

var result = sol.PathSum(root, targetSum);

Console.WriteLine($"Result: {result}, expected: {expected}");


string format(IList<double> data)
{
    return "[" + string.Join(",", data.ToArray()) + "]";
}

public class Solution
{
    public int PathSum(TreeNode root, int targetSum)
    {
        Dictionary<long, long> cache = new Dictionary<long, long>();
        cache.Add(0, 1);
        return (int)Traverse(root, targetSum, 0, cache);
    }

    public long Traverse(TreeNode root, long targetSum, long currentSum, Dictionary<long, long> cache)
    {
        if (root == null) return 0;

        currentSum += root.val;

        long count = 0;

        long diff = currentSum - targetSum; // targetSum = current sum + diff

        if (cache.ContainsKey(diff))
        {
            count = cache[diff];
        }

        if (cache.ContainsKey(currentSum))
        {
            cache[currentSum] += 1;
        }
        else
        {
            cache[currentSum] = 1;
        }

        count += Traverse(root.left, targetSum, currentSum, cache) + Traverse(root.right, targetSum, currentSum, cache);

        cache[currentSum] -= 1;

        return count;
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

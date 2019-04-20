/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int x) { val = x; }
 * }
 */
public class Solution {
    public IList<int> InorderTraversal(TreeNode root) {
        List<int> list = new List<int>();
        if(root == null){
            return list;
        }
        Stack<TreeNode> stack = new Stack<TreeNode>();
        stack.Push(root);
        while(stack.Count > 0){
            TreeNode node = stack.Pop();
            if(node.right != null){
                stack.Push(node.right);
                node.right = null;
            }
            if(node.left != null){
                var left = node.left;
                node.left = null;
                stack.Push(node);
                stack.Push(left);
            }else{
                list.Add(node.val);
            }
        }
        return list;
    }
}
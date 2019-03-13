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
    //runtime: O(n), space complexity: O(1)
    public int MaxDepth(TreeNode root) {
        if(root == null){
            return 0;
        }
        return Traverse(root, 0);
    }
    int Traverse(TreeNode node, int dep){
        int leftDepth = dep + 1;
        if(node.left != null){
            leftDepth = Traverse(node.left, leftDepth);
        }
        int rightDepth = dep + 1;
        if(node.right != null){
            rightDepth = Traverse(node.right, rightDepth);
        }
        return Math.Max(leftDepth, rightDepth);
    }
}
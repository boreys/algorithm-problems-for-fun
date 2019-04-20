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
        traverse(list, root);
        return list;
    }
    void traverse(IList<int> list, TreeNode node){
        if(node == null){
            return;
        }
        traverse(list, node.left);
        list.Add(node.val);
        traverse(list, node.right);
    }
}
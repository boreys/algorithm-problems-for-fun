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
    public TreeNode InorderSuccessor(TreeNode root, TreeNode p) {
        TreeNode result = null;
        TreeNode ptr = root;
        while(ptr != null){
            if(ptr.val > p.val){
                result = ptr;
                ptr = ptr.left;
            }else{
                ptr = ptr.right;
            }
        }
        return result;
    }
}
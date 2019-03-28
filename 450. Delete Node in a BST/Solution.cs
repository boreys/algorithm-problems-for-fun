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
    public TreeNode DeleteNode(TreeNode root, int key) {
        if(root == null){
            return null;
        }
        if(key < root.val){
            root.left = DeleteNode(root.left, key);
        }else if(key > root.val){
            root.right = DeleteNode(root.right, key);
        }else{
            if(root.left != null && root.right != null){
                root.val = findMin(root.right);
                root.right = DeleteNode(root.right, root.val);
            }else if(root.left != null){
                root = root.left;
            }else{
                root = root.right;
            }
        }
        return root;
    }
    int findMin(TreeNode node){
        while(node.left != null){
            node = node.left;
        }
        return node.val;
    }
}
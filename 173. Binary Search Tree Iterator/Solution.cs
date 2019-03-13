/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int x) { val = x; }
 * }
 */
public class BSTIterator {
    Queue<int> data;
    public BSTIterator(TreeNode root) {
        data = new Queue<int>();
        Traverse(root);
    }
    void Traverse(TreeNode node){
        if(node == null){
            return;
        }
        Traverse(node.left);
        data.Enqueue(node.val);
        Traverse(node.right);
    }
    
    /** @return the next smallest number */
    public int Next() {
        return data.Dequeue();
    }
    
    /** @return whether we have a next smallest number */
    public bool HasNext() {
        return data.Count > 0;
    }
}

/**
 * Your BSTIterator object will be instantiated and called as such:
 * BSTIterator obj = new BSTIterator(root);
 * int param_1 = obj.Next();
 * bool param_2 = obj.HasNext();
 */
public class Solution {
    public int KthSmallest(TreeNode root, int k) {
        Queue<int> que = new Queue<int>();
        traverse(root,que);
        int counter = 0;
        int result = 0;
        while(counter != k && que.Count > 0){
            result = que.Dequeue();
            counter++;
        }
        return result;
    }
    void traverse(TreeNode node, Queue<int> que){
        if(node == null){
            return;
        }
        traverse(node.left, que);
        que.Enqueue(node.val);
        traverse(node.right, que);
    }
}
 public class TreeNode {
    public int val;
    public TreeNode left;
    public TreeNode right;
    public TreeNode(int x) { val = x; }
}
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
    //runtime: O(n), space complexity: O(n)
    public IList<IList<int>> ZigzagLevelOrder(TreeNode root) {
        IList<IList<int>> list = new List<IList<int>>();
        if(root == null){
            return list;
        }
        bool reverse = false;
        Queue<TreeNode> que = new Queue<TreeNode>();
        que.Enqueue(root);
        while(que.Count > 0){
            int stop = que.Count;
            IList<int> sublist = new List<int>();
            for(int i=0;i<stop;i++){
                TreeNode node = que.Dequeue();
                sublist.Add(node.val);
                if(node.left != null){
                    que.Enqueue(node.left);
                }
                if(node.right != null){
                    que.Enqueue(node.right);
                }
            }
            if(reverse){
                reverse = false;
                Reverse(sublist);
            }else{
                reverse = true;
            }
            list.Add(sublist);
        }
        return list;
    }
    void Reverse(IList<int> sublist){
        int start = 0;
        int end = sublist.Count-1;
        while(start < end){
            int tmp = sublist[start];
            sublist[start] = sublist[end];
            sublist[end] = tmp;
            start++;
            end--;
        }
    }
}
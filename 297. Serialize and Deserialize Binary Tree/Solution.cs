/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int x) { val = x; }
 * }
 */
public class Codec {

    // Encodes a tree to a single string.
    public string serialize(TreeNode root) {
        List<char> list = new List<char>();
        traverse(root,list);
        return new string(list.ToArray());
    }
    void traverse(TreeNode node, List<char> list){
        if(node == null) return;
        
        list.AddRange(node.val.ToString().ToCharArray());
        
        if(node.left == null && node.right == null) return;
        
        list.Add('[');
        traverse(node.left, list);
        list.Add(' ');
        traverse(node.right, list);
        list.Add(']');
    }

    // Decodes your encoded data to tree.
    public TreeNode deserialize(string data) {
        Queue<char> que = new Queue<char>(data.ToCharArray());
        return deserializeString(que);
    }
    public TreeNode deserializeString(Queue<char> que) {
        if (que.Count == 0) return null;

        string str = "";
        while (que.Count > 0 && ((que.Peek() >= '0' && que.Peek() <= '9') || que.Peek() == '-'))
        {
            str += que.Dequeue();
        }
        if (str.Length == 0) return null;

        int val = Convert.ToInt32(str);
        TreeNode node = new TreeNode(val);
        if(que.Count > 0 && que.Peek() != '[')
        {
            return node;
        }
        if (que.Count > 0) que.Dequeue();
        
        node.left = deserializeString(que);

        if (que.Count > 0) que.Dequeue();

        node.right = deserializeString(que);

        if (que.Count > 0) que.Dequeue();

        return node;
    }
}

// Your Codec object will be instantiated and called as such:
// Codec codec = new Codec();
// codec.deserialize(codec.serialize(root));
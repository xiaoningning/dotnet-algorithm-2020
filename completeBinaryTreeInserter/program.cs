/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int x) { val = x; }
 * }
 */
public class CBTInserter {

    public CBTInserter(TreeNode root) {
        q = new Queue<TreeNode>();
        treeRoot = root;
        q.Enqueue(root);
        // q is only the last node
        while (q.Any()) {
            var t = q.Peek(); 
            if (t.left == null || t.right == null) break;
            q.Enqueue(t.left);
            q.Enqueue(t.right);  
            q.Dequeue();
        }
    }
    
    public int Insert(int v) {
        var node = new TreeNode(v);
        var t = q.Peek(); 
        if (t.left == null) t.left = node;
        else {
            t.right = node;
            q.Enqueue(t.left);
            q.Enqueue(t.right);
            q.Dequeue();
        }
        return t.val;
    }
    
    public TreeNode Get_root() {
        return treeRoot;
    }
    TreeNode treeRoot;
    Queue<TreeNode> q;
}

/**
 * Your CBTInserter object will be instantiated and called as such:
 * CBTInserter obj = new CBTInserter(root);
 * int param_1 = obj.Insert(v);
 * TreeNode param_2 = obj.Get_root();
 */

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
    public IList<IList<int>> LevelOrder(TreeNode root) { 
        var res = new List<IList<int>>();
        LevelOrder(root, 0, res);
        return res;
    }
    void LevelOrder(TreeNode root, int level, List<IList<int>> res) {
        if (root == null) return;
        if (res.Count == level) res.Add(new List<int>());
        res[level].Add(root.val);
        LevelOrder(root.left, level+1, res);
        LevelOrder(root.right, level+1, res);
    }
    public IList<IList<int>> LevelOrder1(TreeNode root) {
        List<IList<int>> res = new List<IList<int>>();
        if (root == null) return res;
        Queue<TreeNode> q = new Queue<TreeNode>();
        q.Enqueue(root);
        while(q.Count != 0){
            List<int> level = new List<int>();
            int size = q.Count;
            for(int i = 0; i < size; i++){
                TreeNode t = q.Dequeue();
                level.Add(t.val);
                if(t.left != null) q.Enqueue(t.left);
                if(t.right != null) q.Enqueue(t.right);
            }
            res.Add(level);
        }
        return res;
    }
}

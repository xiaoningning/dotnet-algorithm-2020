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
    public IList<IList<int>> VerticalOrder(TreeNode root) { 
        var res = new List<IList<int>>();
        if (root == null) return res;
        var m = new SortedDictionary<int, List<int>>();
        var q = new Queue<Tuple<int, TreeNode>>();
        q.Enqueue(new Tuple<int, TreeNode>(0, root));
        while (q.Any()) {
            var t = q.Dequeue();
            if (!m.ContainsKey(t.Item1)) m.Add(t.Item1, new List<int>());
            m[t.Item1].Add(t.Item2.val);
            if (t.Item2.left != null) 
                q.Enqueue(new Tuple<int, TreeNode>(t.Item1 - 1, t.Item2.left));
            if (t.Item2.right != null) 
                q.Enqueue(new Tuple<int, TreeNode>(t.Item1 + 1, t.Item2.right));
        }
        foreach (var kv in m) res.Add(kv.Value);
        return res;
    }
    public IList<IList<int>> VerticalOrder1(TreeNode root) {
        List<IList<int>> res = new List<IList<int>>();
        if(root == null) return res;
        
        Dictionary<int,List<int>> map = new Dictionary<int,List<int>>();
        Queue<TreeNode> qNode = new Queue<TreeNode>();
        Queue<int> qCol = new Queue<int>();
        int min = 0;
        int max = 0;
        
        qNode.Enqueue(root);
        qCol.Enqueue(0);
        
        while(qNode.Count != 0){
            var t = qNode.Dequeue();
            int col = qCol.Dequeue();
            if (!map.ContainsKey(col)) {
                map.Add(col, new List<int>());
            }
            map[col].Add(t.val);    
            
            if(t.left != null){
                qNode.Enqueue(t.left);
                qCol.Enqueue(col - 1);
                min = Math.Min(min, col - 1);
            }
            if(t.right != null){
                qNode.Enqueue(t.right);
                qCol.Enqueue(col + 1);
                max = Math.Max(max, col + 1);
            }
        }
        for (int i = min; i <= max; i++) {
            if (map.ContainsKey(i)) res.Add(map[i]);
        }
        return res;
    }
}

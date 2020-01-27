/*
// Definition for a Node.
public class Node {
    public int val;
    public IList<Node> children;

    public Node() {}

    public Node(int _val) {
        val = _val;
    }

    public Node(int _val, IList<Node> _children) {
        val = _val;
        children = _children;
    }
}
*/
public class Solution {
    public IList<IList<int>> LevelOrder(Node root) {
        var res = new List<IList<int>>();
        if (root == null) return res;
        var q = new Queue<Node>();
        q.Enqueue(root);
        while (q.Any()) {
            var t = new List<int>();
            int cnt = q.Count;
            for (int i = 0; i < cnt; i++) {
                var n = q.Dequeue();
                t.Add(n.val);
                foreach (var c in n.children) q.Enqueue(c);
            }
            res.Add(t);
        }
        return res;
    }
    public IList<IList<int>> LevelOrder1(Node root) {
        var res = new List<IList<int>>();
        LevelOrder(root, 0, res);
        return res;
    }
    void LevelOrder(Node root, int level, List<IList<int>> res) {
        if (root == null) return;
        if (res.Count == level) res.Add(new List<int>());
        res[level].Add(root.val);
        foreach (var c in root.children)
            LevelOrder(c, level+1, res);
    }
}

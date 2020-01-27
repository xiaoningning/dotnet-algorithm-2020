/*
// Definition for a Node.
public class Node {
    public int val;
    public IList<Node> children;

    public Node() {}

    public Node(int _val) {
        val = _val;
    }

    public Node(int _val,IList<Node> _children) {
        val = _val;
        children = _children;
    }
}
*/
public class Solution {
    public IList<int> Preorder(Node root) {
        var res = new List<int>();
        Preorder(root, res);
        return res;
    }
    void Preorder(Node root, List<int> res) {
        if (root == null) return;
        res.Add(root.val);
        foreach (var c in root.children)
            Preorder(c, res);
    }
}

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
public class Codec {

    // Encodes a tree to a single string.
    public string serialize(Node root) {
        var res = new List<string>();
        serializeHelper(root, res);
        return string.Join(",", res);
    }
    
    void serializeHelper(Node node, List<string> res) {
        if (node == null) return;
        else {
            res.Add(node.val.ToString());
            res.Add(node.children.Count.ToString());
            foreach (var c in node.children) {
                serializeHelper(c, res);
            }
        }
    }

    // Decodes your encoded data to tree.
    public Node deserialize(string data) {
        if (string.IsNullOrEmpty(data)) return null;
        return deserializeHelper(data.Split(",").ToList());            
    }

    Node deserializeHelper(List<string> nodes)
    {
        if(nodes.Count == 0) return null;
        string node = nodes[0];
        nodes.RemoveAt(0);
        int size = 0;
        if (nodes.Any()) {
            size = Int32.Parse(nodes[0]);
            nodes.RemoveAt(0);
        }
        var val = Int32.Parse(node);
        Node tn = new Node(val, new List<Node>());
        for (int i = 0; i < size; ++i) {
            tn.children.Add(deserializeHelper(nodes));
        }
        return tn;
    }
}

// Your Codec object will be instantiated and called as such:
// Codec codec = new Codec();
// codec.deserialize(codec.serialize(root));

/*
// Definition for a Node.
public class Node {
    public int val;
    public IList<Node> neighbors;

    public Node(){}
    public Node(int _val,IList<Node> _neighbors) {
        val = _val;
        neighbors = _neighbors;
}
*/
public class Solution {
    public Node CloneGraph(Node node) {
        // record who has been cloned.
        var map = new Dictionary<int, Node>();
        return Clone(node, map);
    }
    Node Clone(Node node, Dictionary<int, Node> map){
        if(node == null) return node;
        if(map.ContainsKey(node.val)) return map[node.val];
        Node newNode = new Node(node.val, new List<Node>());
        map[node.val] = newNode;
        foreach(var n in node.neighbors){
            newNode.neighbors.Add(Clone(n, map));
        }        
        return newNode;
    }
}

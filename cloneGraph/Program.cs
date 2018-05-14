using System;
using System.Collections.Generic;

namespace cloneGraph
{
    class Program
    {
        static void Main(string[] args)
        {
            var obj = new Solution();
            var root = new UndirectedGraphNode(0);
            root.neighbors.Add(new UndirectedGraphNode(1));
            root.neighbors.Add(new UndirectedGraphNode(2));
            var ng = obj.CloneGraph(root);
            Console.WriteLine("clone graph");
        }
    }
    /**
    * Definition for undirected graph.
    */
    public class UndirectedGraphNode {
        public int label;
        public IList<UndirectedGraphNode> neighbors;
        public UndirectedGraphNode(int x) { label = x; neighbors = new List<UndirectedGraphNode>(); }
    }
    public class Solution {
        public UndirectedGraphNode CloneGraph(UndirectedGraphNode node) {
            Dictionary<int, UndirectedGraphNode> map = new Dictionary<int, UndirectedGraphNode>();
            return Clone(node, map);
        }
        UndirectedGraphNode Clone(UndirectedGraphNode node, Dictionary<int, UndirectedGraphNode> map){
            if(node == null) return node;
            if(map.ContainsKey(node.label)) return map[node.label];
            UndirectedGraphNode newNode = new UndirectedGraphNode(node.label);
            map[node.label] = newNode;
            foreach(var n in node.neighbors){
                newNode.neighbors.Add(Clone(n, map));
            }        
            return newNode;
        }
    }
}

using System;
using System.Collections.Generic;

namespace graphValidTree
{
    class Program
    {
        static void Main(string[] args)
        {
            var obj = new Solution(); 
            Console.WriteLine("Graph is valid tree:{0}", obj.ValidTree(1, new int[,]{}));
            Console.WriteLine("Graph is valid tree:{0}", obj.ValidTree1(3, new int[,]{{0,1},{0,2}}));
        }
    }
    public class Solution {
        public bool ValidTree1(int n, int[,] edges) {
            // tree is no cycle connected of graph
            // Union Find the common root of two nodes
            int[] nodeRoots = new int[n];
            for(int i = 0; i < n; i++) nodeRoots[i] = -1;
            for(int e = 0; e < edges.GetLength(0); e++){
                int x = FindRoot(nodeRoots, edges[e,0]);
                int y = FindRoot(nodeRoots, edges[e,1]);
                // nodes have the same root
                // they are cyclely connected.
                if (x == y) return false;
                // x and y is connected
                nodeRoots[x] = y;
            }
            return edges.GetLength(0) == n - 1;
        }

        int FindRoot(int[] roots, int i){
            // it has a root
            while (roots[i] != -1) i = roots[i];
            return i;
        }
        
        public bool ValidTree(int n, int[,] edges) {
            // tree is no cycle connected of graph
            Dictionary<int, HashSet<int>> g = new Dictionary<int, HashSet<int>>();
            Queue<int> q = new Queue<int>();        
            HashSet<int> visited = new HashSet<int>();
            for(int e = 0; e < edges.GetLength(0); e++){
                if(!g.ContainsKey(edges[e,0])) g[edges[e,0]] = new HashSet<int>();
                if(!g.ContainsKey(edges[e,1])) g[edges[e,1]] = new HashSet<int>();
                g[edges[e,0]].Add(edges[e,1]);
                g[edges[e,1]].Add(edges[e,0]);
            }
            q.Enqueue(0);
            visited.Add(0);
            while(q.Count != 0){
                int node = q.Dequeue();
                // some node could not have any edge
                // if it is one node, it is ok
                // otherwise it is not a tree being judged by return condition
                if(!g.ContainsKey(node)) continue;
                else {
                    foreach(int a in g[node]){
                        if(visited.Contains(a)) return false;
                        visited.Add(a);
                        q.Enqueue(a);
                        g[a].Remove(node);
                    }                
                }
            }
            return visited.Count == n;
        }        
    }
}

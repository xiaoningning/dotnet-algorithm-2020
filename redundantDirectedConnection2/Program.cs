using System;

namespace redundantDirectedConnection2
{
    class Program
    {
        static void Main(string[] args)
        {
            var obj = new Solution();
            int[,] edges = new int[,]{
                {1,2}, {2,3}, {3,4}, {4,1}, {1,5}
            };
            Console.WriteLine("Find Redundant Directed Connection");
            Console.WriteLine("{0}", string.Join(",", obj.FindRedundantDirectedConnection(edges)));
        }
    }
    public class Solution {
        public int[] FindRedundantDirectedConnection(int[,] edges) {
            // two invalid cases:
            // one node has two parents
            // a cyclic graph
            int size = edges.Length;
            int[] roots = new int[size + 1];
            int[] res1 = new int[]{-1,-1};
            int[] res2 = new int[]{-1,-1};
            for(int i = 0; i < edges.GetLength(0); i++){
                if(roots[edges[i,1]] == 0){
                    roots[edges[i,1]] = edges[i,0]; 
                }
                else{
                    // the nodes with common root
                    res1 = new int[]{roots[edges[i,1]], edges[i,1]};
                    res2 = new int[]{edges[i,0], edges[i,1]};
                    edges[i,1] = 0; //remove this edge
                }
            }
            
            //reset root
            for(int i = 0; i < roots.Length; i++){
                roots[i] = i;
            }
            // search again after remove one edge with common root
            for(int i = 0; i < edges.GetLength(0); i++){
                if (edges[i, 1] == 0) continue;
                int x = FindRoot(roots, edges[i,0]), y = FindRoot(roots, edges[i,1]);
                // there is a cycle in graph
                if (x == y) return res1[0] == -1 ? new int[]{edges[i,0], edges[i,1]} : res1;
                roots[x] = y;
            }
            return res2;
        }
        int FindRoot(int[] roots, int i){
            while(i != roots[i]) i = roots[i];
            return i;
        }
    }
}

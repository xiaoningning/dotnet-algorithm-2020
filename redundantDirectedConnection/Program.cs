using System;

namespace redundantDirectedConnection
{
    class Program
    {
        static void Main(string[] args)
        {
            var obj = new Solution();
            int[,] edges = new int[,]{
                {1,2}, {2,3}, {3,4}, {4,1}, {1,5}
            };
            Console.WriteLine("Find Redundant Connection");
            Console.WriteLine("{0}", string.Join(",", obj.FindRedundantConnection(edges)));
        }
    }
    public class Solution {
        public int[] FindRedundantConnection(int[,] edges) {
            int size = edges.Length;
            int[] roots = new int[size + 1];
            for(int i = 0; i < roots.Length; i++){
                roots[i] = i;
            }
            
            // undirected graph
            for(int i = 0; i < edges.GetLength(0); i++){
                int x0 = edges[i,0], x1 = edges[i,1];
                // find the common root
                if (FindRoot(roots, x0) == FindRoot(roots, x1)) {
                    return new int[]{x0, x1};
                }
                else{
                    // update root since x0,x1 is connected
                    roots[FindRoot(roots, x0)] = FindRoot(roots, x1);
                }
            }
            return new int[2];
        }
        int FindRoot(int[] roots, int i){
            while(i != roots[i]) i = roots[i];
            return i;
        }
    }
}

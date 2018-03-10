using System;
using System.Collections.Generic;

namespace IsBipartite
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Is Graph Bipartite input hard coded");
            int[][] g = new int[4][];
            g[0] = new int[]{1,3};
            g[1] = new int[]{0,2};
            g[2] = new int[]{1,3};
            g[3] = new int[]{0,2};
            Console.WriteLine("Is Graph Bipartite: {0}", IsBipartite(g));
        }

        static bool IsBipartite(int[][] graph){
            int n = graph.GetLength(0);
            int[] color = new int[n];
            Queue<int> q = new Queue<int>();
            for(int i = 0; i < n; i++){
                if (color[i] != 0) continue;
                color[i] = 1;
                q.Enqueue(i);
                while (q.Count > 0){
                    int t = q.Dequeue();
                    foreach(int node in graph[t]){
                        if (color[node] == color[t]) return false;
                        if (color[node] == 0){
                            color[node] = -1 * color[t];
                            q.Enqueue(node);
                        }
                    }
                }

            }
            return true;
        }
    }
}

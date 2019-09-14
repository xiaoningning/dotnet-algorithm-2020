using System;
using System.Collections.Generic;

namespace numIslands2
{
    class Program
    {
        static void Main(string[] args)
        {
            var obj = new Solution();
            int[,] p = new int[,]{{0,0}, {0,1}, {1,2}, {2,1}};
            Console.WriteLine("num of islands {0}", string.Join(',',obj.NumIslands2(3,3, p)));
        }
    }
    public class Solution {
        public IList<int> NumIslands2(int m, int n, int[,] positions) {
            List<int> res = new List<int>();
            // index of all nodes
            int[] nodeRoots = new int[m*n];
            int cnt = 0;
            int[,] directions = new int[,]{{0, -1}, {-1, 0}, {0, 1}, {1, 0}};
            for(int i = 0; i < m*n; i++) nodeRoots[i] = -1;
            for(int i = 0; i < positions.GetLength(0); i++){
                int id = n * positions[i,0] + positions[i,1];
                nodeRoots[id] = id;
                cnt++;
                // if neighbors have a root, now they are connected
                // then it should share their neighbors' root.
                for(int j = 0; j < directions.GetLength(0); j++){
                    int x = positions[i,0] + directions[j, 0];
                    int y = positions[i,1] + directions[j, 1];
                    int curr_id = n * x + y;
                    if (x < 0 || x >= m || y < 0 || y >= n || nodeRoots[curr_id] == -1) continue;
                    int p = FindRoot(nodeRoots, curr_id);
                    int q = FindRoot(nodeRoots, id);
                    if (p != q) {
                        nodeRoots[p] = q;
                        --cnt;
                    }
                }            
                res.Add(cnt);
            }
            return res;
        }
        
        int FindRoot(int[] roots, int i){
            // the root has itself as root.        
            while (roots[i] != i){
                i = roots[i];            
            } 
            return i;
        }
    }
}

public class Solution1 {
    public IList<int> NumIslands2(int m, int n, int[][] positions) {
        List<int> res = new List<int>();
        // index of all nodes
        int[] nodeRoots = new int[m*n];
        int cnt = 0;
        int[,] directions = new int[,]{{0, -1}, {-1, 0}, {0, 1}, {1, 0}};
        for(int i = 0; i < m*n; i++) nodeRoots[i] = -1;
        for(int i = 0; i < positions.GetLength(0); i++){
            // normalize x, y coordinate
            int id = n * positions[i][0] + positions[i][1];
            if (nodeRoots[id] == -1) {
                nodeRoots[id] = id;
                cnt++;
            }
            // if neighbors have a root, now they are connected
            // then it should share their neighbors' root.
            for(int j = 0; j < directions.GetLength(0); j++){
                int x = positions[i][0] + directions[j, 0];
                int y = positions[i][1] + directions[j, 1];
                int curr_id = n * x + y;
                if (x < 0 || x >= m || y < 0 || y >= n || nodeRoots[curr_id] == -1) continue;
                int p = FindRoot(nodeRoots, curr_id);
                int q = FindRoot(nodeRoots, id);
                if (q != p) {
                    nodeRoots[q] = p;
                    --cnt;
                }
            }            
            res.Add(cnt);
        }
        return res;
    }
    
    int FindRoot(int[] roots, int i){
        // the root has itself as root.        
        while (roots[i] != i){
            // path compression
            roots[i] = roots[roots[i]];
            i = roots[i];            
        } 
        return i;
    }
}

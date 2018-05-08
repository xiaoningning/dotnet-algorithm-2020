using System;

namespace numIslands
{
    class Program
    {
        static void Main(string[] args)
        {
            var obj = new Solution();
            char[,] grid = new char[,]{
                {'1', '1', '0','0'},
                {'1', '0', '0','1'},
                {'0', '1', '0','1'}
            };
            Console.WriteLine("num of islands {0}", obj.NumIslands(grid));
        }
    }
    public class Solution {
        public int NumIslands(char[,] grid) {
            int n = grid.GetLength(0);
            int m = grid.GetLength(1);
            bool[,] visited = new bool[n,m];
            int res = 0;
            for(int i = 0; i < n; i++){
                for(int j = 0; j < m; j++){
                    if(grid[i,j] == '1' && !visited[i,j]){
                        DFS(grid, visited, i, j);            
                        res++; 
                    }
                }
            }
            return res;
        }
        
        void DFS(char[,] grid, bool[,] visited, int i, int j){
            if(i < 0 || i >= grid.GetLength(0)) return;
            if(j < 0 || j >= grid.GetLength(1)) return;
            
            if(grid[i,j] != '1' || visited[i,j]) return;
            else {
                visited[i,j] = true;
                DFS(grid, visited, i, j - 1);
                DFS(grid, visited, i - 1, j);
                DFS(grid, visited, i, j + 1);
                DFS(grid, visited, i + 1, j);
            }
        }
    }
}

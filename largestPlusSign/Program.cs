using System;

namespace largestPlusSign
{
    class Program
    {
        static void Main(string[] args)
        {
            int N = 5;
            int[,] mines = new int[,]{{4,2}};
            var o = new Solution()
            Console.WriteLine("order of largest plus sign: {0}", o.OrderOfLargestPlusSign(N, mines));
        }
    }
    
    public class Solution {
        // time out since repeat of calculation
        // method 1 uses grid[,] to cache the result
        public int OrderOfLargestPlusSign(int N, int[,] mines) {
            int[,] grid = new int[N, N];
            int res = 0;
            for(int i = 0; i < grid.GetLength(0); i++){
                for(int j = 0; j < grid.GetLength(1); j++){
                    grid[i, j] = 1;
                }
            }

            for(int i= 0; i < mines.GetLength(0); i++){
                grid[mines[i,0], mines[i,1]] = 0;
            }

            for(int i = 0; i < grid.GetLength(0); i++){
                for(int j = 0; j < grid.GetLength(1); j++){
                    if(grid[i,j] == 1){
                        int cnt = 1;
                        int dir = 1;
                        while(j-dir >= 0 && j+dir < N  && i-dir >= 0 && i+dir < N  && 
                             grid[i,j-dir] == 1 && grid[i,j+dir] == 1 && 
                             grid[i-dir,j] == 1 && grid[i+dir,j] == 1){
                            cnt++;
                            dir++;    
                        }
                        res = Math.Max(cnt, res);
                    }
                }
            }
            return res;
        }
        public int OrderOfLargestPlusSign1(int N, int[,] mines) {
            int[,] grid = new int[N, N];

            for(int i = 0; i < grid.GetLength(0); i++){
                for(int j = 0; j < grid.GetLength(1); j++){
                    grid[i, j] = N;
                }
            }

            for(int i= 0; i < mines.GetLength(0); i++){
                grid[mines[i,0], mines[i,1]] = 0;
            }

            for(int i = 0; i < grid.GetLength(0); i++){
                int left = 0, right = 0, up = 0, down = 0;
                for(int j = 0, k = N - 1; j < grid.GetLength(1); j++, k--){
                    grid[i,j] = Math.Min(grid[i,j], left = grid[i,j] == 0 ? 0 : ++left );
                    grid[i,k] = Math.Min(grid[i,k], right = grid[i,k] == 0 ? 0 : ++right );
                    grid[j,i] = Math.Min(grid[j,i], up = grid[j,i] == 0 ? 0 : ++up );
                    grid[k,i] = Math.Min(grid[k,i], down = grid[k,i] == 0 ? 0 : ++down );
                }
            }

            int res = 0;    
            for (int i = 0; i < grid.GetLength(0); i++) {
                for (int j = 0; j < grid.GetLength(1); j++) {
                    res = Math.Max(res, grid[i, j]);
                }
            }
            return res;
        }
    }
}

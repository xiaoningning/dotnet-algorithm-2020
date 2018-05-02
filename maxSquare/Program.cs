using System;

namespace maxSquare
{
    class Program
    {
        static void Main(string[] args)
        {
            var obj = new Solution();
            char[,] m = new char[,]{
                {'1','0', '1', '0'},
                {'1','1', '1', '0'},
                {'1','1', '1', '0'},
                {'1','0', '1', '0'}
            };
            Console.WriteLine("maximul sequare {0}", obj.MaximalSquare(m));
        }
    }
    public class Solution {
        public int MaximalSquare(char[,] matrix) {
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            int[,] dp = new int[n+1, m+1];
            int res = 0;
            for(int i = 1; i <= n; i++){
                for(int j = 1; j <= m; j++){
                    if(matrix[i-1, j-1] == '1'){
                        dp[i,j] = Math.Min(dp[i-1, j-1], Math.Min(dp[i, j-1], dp[i-1, j])) + 1;
                        res = Math.Max(res, dp[i,j]);
                    }
                }
            }
            return res * res;
        }
    }
}

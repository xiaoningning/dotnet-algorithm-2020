using System;

namespace rangeQuerySum2D_Immutable
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] matrix = new int[,]{
                {3, 0, 1, 4, 2},
                {5, 6, 3, 2, 1},
                {1, 2, 0, 1, 5},
                {4, 1, 0, 1, 7},
                {1, 0, 3, 0, 5}
            };
            NumMatrix obj = new NumMatrix(matrix);
            Console.WriteLine("sum range 2, 1, 4, 3 :{0}", obj.SumRegion(2, 1, 4, 3));           
            Console.WriteLine("sum range 1, 1, 2, 2: {0}", obj.SumRegion(1, 1, 2, 2));
            Console.WriteLine("sum range 1, 2, 2, 4: {0}", obj.SumRegion(1, 2, 2, 4));  
        }
    }

    public class NumMatrix {
        int[,] dp;
        public NumMatrix(int[,] matrix) {
            int row = matrix.GetLength(0);
            int col = matrix.GetLength(1);
            if (row == 0 || col == 0) return;
            dp = new int[row+1, col+1];
            for(int r = 0; r < row; r++){
                for(int c = 0; c < col; c++){
                    dp[r + 1, c + 1] = dp[r + 1, c] + dp[r, c + 1] + matrix[r,c] - dp[r,c];
                }
            }
        }
        
        public int SumRegion(int row1, int col1, int row2, int col2) {
            return dp[row2 + 1,col2 + 1] - dp[row1, col2 + 1] - dp[row2 + 1, col1] + dp[row1, col1];
        }
    }

    /**
    * Your NumMatrix object will be instantiated and called as such:
    * NumMatrix obj = new NumMatrix(matrix);
    * int param_1 = obj.SumRegion(row1,col1,row2,col2);
    */
}

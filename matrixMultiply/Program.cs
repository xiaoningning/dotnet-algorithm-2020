using System;

namespace matrixMultiply
{
    class Program
    {
        static void Main(string[] args)
        {
            var obj = new Solution();
            int[,] a = new int[,]{
                {1, 0, 0},
                {-1, 0, 3}
            };
            int[,] b = new int[,]{
                {7, 0, 0},
                {0, 0, 0},
                {0, 0, 1}
            };
            var res = obj.Multiply(a, b);
            foreach(var r in res){
                Console.WriteLine("result list: {0}", string.Join(',', r));
            }
        }
    }
    public class Solution {
        public int[,] Multiply(int[,] A, int[,] B) {
            int n = A.GetLength(0);
            int m = B.GetLength(1);
            int[,] res = new int[n,m];
            for (int i = 0; i < A.GetLength(0); ++i) {
                for (int k = 0; k < A.GetLength(1); ++k) {
                    if (A[i,k] != 0) {
                        for (int j = 0; j < B.GetLength(1); ++j) {
                            if (B[k,j] != 0) res[i,j] += A[i,k] * B[k,j];
                        }
                    }
                }
            }
            return res;
        }
    }
}

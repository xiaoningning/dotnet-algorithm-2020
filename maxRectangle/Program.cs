using System;
using System.Collections.Generic;

namespace maxRectangle
{
    class Program
    {
        static void Main(string[] args)
        {
            var obj = new Solution();
            char[,] matrix = new char[,]{
                {'1','0','1','0','0'},
                {'1','0','1','1','1'},
                {'1','1','1','1','1'},
                {'1','0','0','1','0'}
            };
            Console.WriteLine("max rectagle {0}", obj.MaximalRectangle(matrix));
        }
    }
    public class Solution {
        public int MaximalRectangle(char[,] matrix) {
            int m = matrix.GetLength(0);
            int n = matrix.GetLength(1);
            int[] heights = new int[n+1];
            int res = 0;
            for(int i = 0; i < m; i++){
                Stack<int> st = new Stack<int>();
                for(int j = 0; j <= n; j++){
                    heights[j] = j < n && matrix[i,j] == '1' ? heights[j] + 1 : 0;    
                    while(st.Count != 0 && heights[st.Peek()] >= heights[j]){
                        int cur = st.Pop();
                        res = Math.Max(res, heights[cur] * (st.Count == 0 ? j : j - st.Peek() - 1));
                    }
                    st.Push(j);
                }            
            }
            return res;
        }
    }
}

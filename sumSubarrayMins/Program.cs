using System;
using System.Collections.Generic;

namespace sumSubarrayMins
{
    class Program
    {
        static void Main(string[] args)
        {
            var obj = new Solution();     
            int[] A= new int[]{3,1,2,4};
            Console.WriteLine("sum of subarray mins: {0}", obj.SumSubarrayMins(A));
        }
    }
    /*
    e.g. given [3,1,2,4],
    For 3, the boudary is: | 3 | ...
    For 1, the boudray is: | 3 1 2 4 |
    For 2, the boudray is: ... | 2 4 |
    For 4, the boudary is: ... | 4 |
     */
    public class Solution {
        public int SumSubarrayMins(int[] A) {
            int M = (int)1e9 + 7;
            int n = A.Length;
            int[] right = new int[n], left = new int[n];
            int res = 0;
            Stack<int[]> stack = new Stack<int[]>();
            for (int i = 0; i < n; i++){
                int cnt = 1;
                while (stack.Count != 0 && stack.Peek()[0] > A[i]) {
                    cnt += stack.Pop()[1];
                }
                stack.Push(new int[]{A[i], cnt});
                left[i] = cnt;
            }
            stack.Clear();
            for (int i = n-1; i >= 0; i--){
                int cnt = 1;
                // it could be equal but only count one side
                while (stack.Count != 0 && stack.Peek()[0] >= A[i]) {
                    cnt += stack.Pop()[1];
                }
                stack.Push(new int[]{A[i], cnt});
                right[i] = cnt;
            }
            for (int i = 0; i < n; i++){
                res = (res + A[i] * left[i] * right[i]) % M;
            }
            return res;
        }
    }
}

using System;

namespace monotonicArray
{
    class Program
    {
        static void Main(string[] args)
        {
            var obj = new Solution();
            int[] A = new int[]{1,2,2,4};
            Console.WriteLine("Is Monotonic Array: {0}", obj.IsMonotonic(A));
        }
    }
    public class Solution {
        public bool IsMonotonic(int[] A) {
            bool inc = true, dec = true;
            for (int i = 1; i < A.Length; i++){
                inc &= A[i -1] <= A[i];
                dec &= A[i -1] >= A[i];
            }
            return inc || dec;
        }
    }
}

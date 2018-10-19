using System;

namespace divide
{
    class Program
    {
        static void Main(string[] args)
        {
            var obj = new Solution();     
            Console.WriteLine("Divide: {0}", obj.Divide(10233, -2));
        }
    }
    public class Solution {
        public int Divide(int dividend, int divisor) {
            long m = Math.Abs((long)dividend), n = Math.Abs((long)divisor);
            long res = 0;
            if (m < n) return 0;
            while (m >= n) {
                long t = n, p = 1;
                while (m > (t << 1)) {
                    t <<= 1;
                    p <<= 1;
                }
                res += p;
                m -= t;
            }
            if ((dividend < 0) ^ (divisor < 0)) res = -res;
            return res > Int32.MaxValue ? Int32.MaxValue : (int)res;
        }
    }
}

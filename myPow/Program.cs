using System;

namespace myPow
{
    class Program
    {
        static void Main(string[] args)
        {
            var obj = new Solution();
            Console.WriteLine("pow(x, n): {0}", obj.MyPow(34, -5));
        }
    }
    public class Solution {
        public double MyPow1(double x, int n) {
            if (n == 0) return 1;
            double half = MyPow(x, n / 2);
            if (n % 2 == 0) return half * half;
            else if (n > 0) return half * half * x;
            else return half * half / x;
        }
        
        public double MyPow(double x, int n) {
            double res = 1.0;
            for (int i = n; i != 0; i /= 2) {
                if (i % 2 != 0) res *= x;
                x *= x;
            }
            return n < 0 ? 1 / res : res;
        }
    }
}

using System;

namespace sqrt
{
    class Program
    {
        static void Main(string[] args)
        {
            var obj = new Solution();
            Console.WriteLine("Sqrt(x) {0}", obj.MySqrt(8));
        }
    }
    public class Solution {
        public int MySqrt(int x) {
            if (x <= 1) return x;
            int right = x, left = 0;
            while (left < right){
                int mid = left + (right - left) / 2;
                // use divide otherwise, it could be overflow int.
                if (x / mid >= mid) left = mid + 1;
                else right = mid;
            }
            return right - 1;
        }
    }
}

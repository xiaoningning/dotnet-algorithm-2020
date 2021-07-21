public class Solution {
    public int NthMagicalNumber(int n, int a, int b) {
        int lcm = a * b / gcd (a, b); // Least Common Multiple
        long left = 2; 
        long right = (long)1e14; 
        long M = (long)1e9 + 7;
        while (left < right) {
            var mid = left + (right - left) / 2;
            // without LCM
            // var cnt = new HashSet<long>();
            // cnt.Add(mid / a); cnt.Add(mid / b);
            // if (cnt.Count() < n) left = mid + 1;
            if (mid / a + mid / b - mid / lcm < n) left = mid + 1;
            else right = mid;
        }
        //Console.WriteLine(right);
        return (int) (right % M);
    }
    // greatest common divisor
    int gcd(int a, int b) {
        return b == 0 ? a : gcd(b, a % b);
    }
}

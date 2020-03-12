public class Solution {
    public int PrimePalindrome(int N) {
        /* For any palindrome with even length:
            abcddcba % 11
            = (a * 10000001 + b * 100001 * 10 + c * 1001 * 100 + d * 11 * 1000) % 11
            = 0
        */
        if (N >= 8 && N <= 11) return 11;
        for (int i = 1; i < 100000; i++) {
            string s = i.ToString();
            string r = new string(s.Reverse().ToArray());
            int y = Int32.Parse(s + r.Substring(1));
            if (y >= N && IsPrime(y)) return y;
        }
        return -1;
    }
    bool IsPrime(int n) {
        if (n < 2 || n % 2 == 0) return n == 2;
        int limit = (int) Math.Sqrt(n);
        for (int i = 3; i <= limit; i++) {
            if (n % i == 0) return false;
        }
        return true;
    }
}

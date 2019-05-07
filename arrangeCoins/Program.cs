public class Solution {
    public int ArrangeCoins1(int n) {
        int cur = 1, rem = n - 1;
        while (rem >= cur + 1) {
            ++cur;
            rem -= cur;
        }
        // O(n)
        return n == 0 ? 0 : cur;
    }
    public int ArrangeCoins(int n) {
        if (n <= 1) return n;
        long low = 1, high = n;
        while (low < high) {
            long mid = low + (high - low) / 2;
            // calculate sum of i... mid
            // sum = (1+n)*n/2
            if (mid * (mid + 1) / 2 <= n) low = mid + 1;
            else high = mid;
        }
        // O(lgn)
        return (int) low - 1;
    }
}

public class Solution {
    // x, x+1, x+2, ..., x+k-1 => sum = N
    // kx + (k-1) * k / 2 = N
    // N - (k-1) * k / 2 > kx > 0
    // 2N + k > k*k => sqrt(2N) > k
    public int ConsecutiveNumbersSum1(int N) {
        int res = 1;
        for (int k = 2; k < Math.Sqrt(2 * N); ++k) {
            if ((N - k * (k - 1) / 2) % k == 0) ++res;
        }
        return res;
    }
    // x, x+1, x+2, ..., x+k-1 => sum = N
    // (k * x ) % x + (0 + 1 + 2, ..., + k-1) % x = N % x == 0
    // (k * x ) % x + sum % x = N % x
    // (k * x ) % x = N % x - sum % x
    public int ConsecutiveNumbersSum(int N) {
        int res = 0, sum = 0;
        for (int i = 1; sum < N; ++i) {
            sum += i;
            if ((N - sum) % i == 0) ++res;
        }
        return res;
    }
}

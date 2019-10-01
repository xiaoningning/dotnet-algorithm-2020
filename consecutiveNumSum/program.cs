public class Solution {
    // x, x+1, x+2, ..., x+k-1
    // kx + (k-1) * k / 2 = N
    // N - (k-1) * k / 2 > kx > 0
    // 2N + k > k*k => sqrt(2N) > k
    public int ConsecutiveNumbersSum(int N) {
        int res = 1;
        for (int k = 2; k < Math.Sqrt(2 * N); ++k) {
            if ((N - k * (k - 1) / 2) % k == 0) ++res;
        }
        return res;
    }
}

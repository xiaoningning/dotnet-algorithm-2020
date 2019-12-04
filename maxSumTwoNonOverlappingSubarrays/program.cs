public class Solution {
    public int MaxSumTwoNoOverlap(int[] A, int L, int M) {
        // prefix sum
        for (int i = 1; i < A.Length; ++i)
            A[i] += A[i - 1];
        // just init, A is not sorted
        int res = A[L + M - 1], Lmax = A[L - 1], Mmax = A[M - 1];
        for (int i = L + M; i < A.Length; ++i) {
            Lmax = Math.Max(Lmax, A[i - M] - A[i - L - M]);
            Mmax = Math.Max(Mmax, A[i - L] - A[i - L - M]);
            // two non-overlapping (contiguous) subarrays
            // => the whole subarray L+M or M+L
            res = Math.Max(res, Math.Max(Lmax + A[i] - A[i - M], Mmax + A[i] - A[i - L]));
        }
        return res;
    }
}

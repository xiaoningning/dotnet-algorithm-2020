public class Solution {
    public int SmallestRangeII(int[] A, int K) {
        int n = A.Length;
        Array.Sort(A);
        int res = A[n-1] - A[0];
        int left = A[0] + K, right = A[n-1] - K;
        for (int i = 0; i < n - 1; ++i)  {
            // find i in which i, i+1 has smallest range
            // since it is sorted. the smallest range must be i and i+1
            int high = Math.Max(right, A[i] + K);
            int low = Math.Min(left, A[i + 1] - K);
            res = Math.Min(res, high - low);
        }
        return res;
    }
}

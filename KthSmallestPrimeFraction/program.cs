public class Solution {
    public int[] KthSmallestPrimeFraction(int[] A, int K) {
        double l = 0, r = 1.0;
        int n = A.Length; // A is sorted
        while (l < r) {
            double m = l + (r - l) / 2;
            double mx = 0.0;
            int p = 0, q = 0, cnt = 0;
            for (int i = 0 , j = 1; i < n -1; i++) {
                while (j < n && A[i] > m * A[j]) j++;
                if (j == n) break;
                // smaller fraction => larger A[j]
                // => cnt is the backward of j
                cnt += n - j;
                double f = (double) A[i] / A[j];
                if ( f > mx) {
                    mx = f;
                    p = i; q = j;
                }   
            }
            if (cnt == K) return new int[]{A[p], A[q]};
            if (cnt < K) l = m; // m is double, no need +1
            else r = m;
        }
        return new int[]{};
    }
}

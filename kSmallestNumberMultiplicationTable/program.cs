public class Solution {
    public int FindKthNumber(int m, int n, int k) {
        int left = 1, right = m * n + 1;
         while (left < right) {
             int mid = left + (right - left) / 2, cnt = 0;
             // each i is n
             for (int i = 1; i <= m; ++i) {
                 // Multiplication table
                 cnt += (mid > n * i) ? n : mid / i;
             }
             if (cnt < k) left = mid + 1;
             else right = mid;
         }
         return right;
    }
}

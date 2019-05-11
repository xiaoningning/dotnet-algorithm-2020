public class Solution {
    public int LongestOnes(int[] A, int K) {
        int i = 0, j, res = 0;
        // slide windows
        for (j = 0; j < A.Length; ++j) {
            if (A[j] == 0) K--;
            if (K < 0 && A[i++] == 0) K++;
            res = Math.Max(res, j - i + 1);
        }
        return res;
    }
}

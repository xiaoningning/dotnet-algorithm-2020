public class Solution {
    public int FixedPoint(int[] A) {
        int l = 0, r = A.Length - 1;
        while (l < r) {
            int m = l + (r - l) / 2;
            if (A[m] - m < 0) l = m + 1;
            else r = m;
        }
        return A[l] == l ? l : -1;
    }
}

public class Solution {
    public int SmallestRangeI(int[] A, int K) {
        int mx = A[0], mn = A[0];
        foreach (int num in A) {
            mx = Math.Max(mx, num);
            mn = Math.Min(mn, num);
        }
        // find the min of Max element 
        // and the max of min element
        // then their range is the smallest range
        return Math.Max(0, mx - mn - 2 * K);
    }
}

public class Solution {
    public int MaximumSum(int[] arr) {
        int ignored = 0, notignored = 0, mx = arr.Max(), res = mx;
        foreach (int a in arr) {
            // ignored current negative
            // or add previous negative, ignore the current one
            ignored = Math.Max(ignored + a, notignored);
            notignored = Math.Max(notignored + a, a);
            res = Math.Max(res, Math.Max(ignored, notignored));
        }
        // all negative cases
        return mx < 0 ? mx : res;
    }
}

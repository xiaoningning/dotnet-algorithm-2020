public class Solution {
    public int KConcatenationMaxSum(int[] arr, int k) {
        // sub array length can be 0 => sum 0
        int n = arr.Length;
        long sum = 0, mx = 0, total = arr.Sum();
        // max array cross border
        for (int i = 0; i < n * Math.Min(k,2); i++) {
            sum = Math.Max(sum + arr[i % n], arr[i % n]);
            mx = Math.Max(mx, sum);
        }
        // each side of arr has partial max arrary => k-2
        long t = Math.Max(mx, mx + total * Math.Max(0,k-2)) % (long)(1e9+7);
        return (int) Math.Max(0,t);
    }
}

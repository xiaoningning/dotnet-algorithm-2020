public class Solution {
    public double FindMaxAverage(int[] nums, int k) {
        int n = nums.Length;
        double[] sum = new double[n+1];
        double left = nums.Min();
        double right = nums.Max();
        while (right - left > 1e-5) {
            double mid = left + (right - left) / 2;
            double minSum = 0;
            bool foundMinAvg = false;
            for (int i = 1; i <= n; i++) {
                // sum = n[i] - avg + n[i-1] -avg ...
                sum[i] = nums[i-1] - mid + sum[i-1];
                // if more than avg, then minSum > 0
                if (i >= k) minSum = Math.Min(minSum, sum[i - k]);
                if (i >= k && sum[i] > minSum) {
                    foundMinAvg = true;
                    break;
                }
            }
            if (foundMinAvg) left = mid;
            else right = mid;
        }
        return left;
    }
}

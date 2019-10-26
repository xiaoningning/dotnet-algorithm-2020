public class Solution {
    public int MaxSubarraySumCircular(int[] A) {
        int sum = 0, maxSum = Int32.MinValue, curMax = 0, minSum = Int32.MaxValue, curMin = 0;
        foreach (int a in A) {
            curMax = Math.Max(curMax + a, a);
            maxSum = Math.Max(maxSum, curMax);
            curMin = Math.Min(curMin + a, a);
            minSum = Math.Min(minSum, curMin);
            sum += a;
        }
        // if all a < 0, maxSum = max(A) and minSum = sum(A)
        // in this case, max(maxSum, total - minSum) = 0
        // normal case, maxSum is maxSum
        // if circular, maxSum is sum - minSum
        return maxSum > 0 ? Math.Max(maxSum, sum - minSum) : maxSum;
    }
}

public class Solution {
    public int ShortestSubarray(int[] A, int K) {
        int res = Int32.MaxValue, n = A.Length;
        int[] sum = new int[n+1];
        var q = new List<int>();
        for (int i = 1; i < n + 1; i++) sum[i] = sum[i-1] + A[i-1];
        // chech sum
        for (int i = 0; i < n + 1; i++) {
            while (q.Any() && sum[i] - sum[q.First()] >= K) {
                res = Math.Min(res, i - q.First());
                q.RemoveAt(0);
            }
            // i is negative => no need to check
            while (q.Any() && sum[i] < sum[q.Last()]) {
                q.RemoveAt(q.Count - 1);
            }
            q.Add(i);
        }
        // no sort of sum => O(n)
        return res == Int32.MaxValue ? -1 : res;
    }
}

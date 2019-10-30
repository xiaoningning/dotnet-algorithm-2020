public class Solution {
    public bool SplitArraySameAverage(int[] A) {
        // average1 = average2 => sum1/k = sum2/(n-k)
        // => sum /n = sum1/k = sum2/(n-k)
        // => sum * k / n = sum1 => sum * k = sum1 * n
        // => sum * k % n == 0 since sum1 is int.
        // k in [1, n / 2]
        int sum = A.Sum(), n = A.Length;
        var dp = new Dictionary<int, HashSet<int>>();
        // sum of any i of elements of A
        // dp[1]= {A0,A1,A2,A3...An-1}
        dp.Add(0, new HashSet<int>(){0});
        foreach (var num in A) {
            for (int i = n/2; i >= 1; --i) {
                if (!dp.ContainsKey(i)) dp.Add(i, new HashSet<int>());
                if (!dp.ContainsKey(i-1)) dp.Add(i-1, new HashSet<int>());
                foreach (var a in dp[i - 1]) {
                    dp[i].Add(a + num);
                }
            }
        }
        for (int i = 1; i <= n/2; ++i) {
            if (sum * i % n == 0 && dp[i].Contains(sum * i / n)) return true;
        }
        return false;
    }
    public bool SplitArraySameAverage1(int[] A) {
        int n = A.Length, sum = A.Sum();
        // i in [1, n / 2]
        for (int i = 1; i <= n / 2; ++i) 
            if (sum * i % n == 0 && find(A, sum * i / n, i, 0))
                return true;
        return false;
    }
    bool find(int[] A, int target, int k, int i) {
        if (k == 0) return target == 0;
        if (k + i > A.Length) return false;
        // has a[i] or not have a[i] to calculate sum
        return find(A, target - A[i], k - 1, i + 1) || find(A, target, k, i + 1);
    }
}

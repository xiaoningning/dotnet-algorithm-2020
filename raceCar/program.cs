public class Solution {
    // BFS + memo
    public int Racecar(int target) {
        int res = 0;
        var q = new Queue<int[]>(); q.Enqueue(new int[]{0, 1});
        var visited = new HashSet<string>(){"0,1"};
        while (q.Any()) {
            for (int i = q.Count; i > 0; --i) {
                int[] t = q.Dequeue();
                int pos = t[0], speed = t[1];
                if (pos == target) return res;
                int newPos = pos + speed, newSpeed = speed * 2;
                string key = newPos + "," + newSpeed;
                if (!visited.Contains(key) && newPos > 0 && newPos < (target * 2)) {
                    visited.Add(key);
                    q.Enqueue(new int[]{newPos, newSpeed});
                }
                newPos = pos; 
                newSpeed = (speed > 0) ? -1 : 1;
                key = newPos + "," + newSpeed;
                if (!visited.Contains(key) && newPos > 0 && newPos < (target * 2)) {
                    visited.Add(key);
                    q.Enqueue(new int[]{newPos, newSpeed});
                }
            }
            ++res;
        }
        return -1;
    }
    // DP
    // 0 -> 1 -> 3 -> 7 -> 15 -> 31
    // target = 2^cnt - 1
    public int Racecar1(int target) {
        int[] dp = new int[target + 1];
        for (int i = 1; i <= target; i++) {
            dp[i] = Int32.MaxValue;
            int j = 1, cnt1 = 1;
            // before i, acclerate
            for (; j < i; j = (1 << ++cnt1) - 1) {
                // revers 1
                for (int k = 0, cnt2 = 0; k < j; k = (1 << ++cnt2) - 1) {
                    dp[i] = Math.Min(dp[i], cnt1 + 1 + cnt2 + 1 + dp[i - (j - k)]);
                }
            }
            // if  pass i, reverse, otherwise cnt1
            dp[i] = Math.Min(dp[i], cnt1 + (i == j ? 0 : 1 + dp[j - i]));
        }
        return dp[target];
    }
}

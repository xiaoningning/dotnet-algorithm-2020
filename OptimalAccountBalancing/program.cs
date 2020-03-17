public class Solution {
    public int MinTransfers(int[][] transactions) {
        var bal = new Dictionary<int, int>();
        foreach(var t in transactions) {
            if (!bal.ContainsKey(t[0])) bal.Add(t[0], 0);
            if (!bal.ContainsKey(t[1])) bal.Add(t[1], 0);
            bal[t[0]] -= t[2];
            bal[t[1]] += t[2];
        }
        var accnt = new List<int>();
        foreach (var kv in bal) if (kv.Value != 0) accnt.Add(kv.Value);
        int res = Int32.MaxValue;
        dfs(0, 0, ref accnt, ref res);
        return res;
    }
    void dfs(int start, int cnt, ref List<int> accnt, ref int res) {
        int n = accnt.Count;
        while (start < n && accnt[start] == 0) ++start;
        if (start == n) {
            res = Math.Min(res, cnt);
        }
        else {
            for (int i = start + 1; i < n; i++) {
                if (accnt[i] * accnt[start] < 0) {
                    accnt[i] += accnt[start];
                    dfs(start + 1, cnt + 1, ref accnt, ref res);
                    accnt[i] -= accnt[start];
                }
            }
        }
    }
}

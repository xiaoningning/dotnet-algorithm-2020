public class Solution {
    public int LastStoneWeight(int[] stones) {
        var q = new List<int>(stones);
        q = q.OrderBy(s => s).ToList();
        while (q.Count > 1) {
            int x = q.Last(); q.RemoveAt(q.Count - 1);
            int y = q.Last(); q.RemoveAt(q.Count - 1);
            if (x == y) continue;
            q.Add(Math.Abs(x - y));
            q = q.OrderBy(s => s).ToList();
        }
        return q.Any() ? q.Last() : 0;
    }
    public int LastStoneWeight1(int[] stones) {
        // 1 <= stones[i] <= 1000
        var m = new int [1001];
        foreach (var s in stones) m[s]++;
        int i = 1000, j;
        while (i > 0) {
            if (m[i] == 0) {
                i--;
                continue;
            }
            else {
                // several the same weights
                m[i] = m[i] % 2;
                if (m[i] == 0) continue;
                // only one m[i]
                j = i - 1;
                while (j > 0 && m[j] == 0) j--;
                if (j == 0) return i;
                m[i - j]++;
                m[j]--;
                m[i]--;
            }
        }
        return 0;
    }
}

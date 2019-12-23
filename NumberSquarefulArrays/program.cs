public class Solution {
    Dictionary<int, int> count = new Dictionary<int, int>();
    Dictionary<int, HashSet<int>> cand = new Dictionary<int, HashSet<int>>();
    int res = 0;
    public int NumSquarefulPerms(int[] A) {
        foreach (int a in A) count[a] = count.GetValueOrDefault(a,0) + 1;
        foreach (var i in count) {
            foreach (var j in count) {
                int x = i.Key, y = j.Key, s = (int) Math.Sqrt(x + y);
                if (!cand.ContainsKey(x)) cand.Add(x, new HashSet<int>());
                // sqrt is double => check here as int
                if (s * s == x + y) cand[x].Add(y);
            }
        }
        // combination of candidates
        var ks = count.Keys.ToList();
        foreach (var k in ks) dfs(k, A.Length - 1);
        return res;
    }
    // back track
    void dfs(int x, int left) {
        count[x]--;
        if (left == 0) res++;
        foreach (int y in cand[x])
            if (count[y] > 0) dfs(y, left - 1);
        count[x]++;
    }
}

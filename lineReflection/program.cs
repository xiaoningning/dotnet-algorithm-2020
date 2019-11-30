public class Solution {
    public bool IsReflected(int[][] points) {
        var m = new Dictionary<int,HashSet<int>>();
        int mn = Int32.MaxValue, mx = Int32.MinValue;
        foreach (var p in points) {
            mx = Math.Max(mx, p[0]);
            mn = Math.Min(mn, p[0]);
            if (!m.ContainsKey(p[0])) m.Add(p[0], new HashSet<int>());
            m[p[0]].Add(p[1]);
        }
        double y = (double)(mx + mn) / 2;
        foreach (var p in points) {
            int t  = (int) (2 * y - p[0]);
            if (!m.ContainsKey(t) || !m[t].Contains(p[1])) return false;
        }
        return true;
    }
}

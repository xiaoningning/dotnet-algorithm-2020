public class Solution {
    public int MinAreaRect(int[][] points) {
        var m = new Dictionary<int, List<int>>();
        foreach (var p in points) {
            if (!m.ContainsKey(p[0])) m.Add(p[0], new List<int>());
            m[p[0]].Add(p[1]);
        }
        int res = Int32.MaxValue;
        foreach (var p1 in points) {
            foreach (var p2 in points) {
                // the same or the same line
                if (p1[0] == p2[0] || p1[1] == p2[1]) continue;
                // find rectangle
                if (m[p1[0]].Contains(p2[1]) && m[p2[0]].Contains(p1[1])) {
                    res = Math.Min(res, Math.Abs((p1[0] - p2[0]) * (p1[1] - p2[1])));
                }
            }
        }
        return res == Int32.MaxValue ? 0 : res;
    }
}

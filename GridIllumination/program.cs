public class Solution {
    public int[] GridIllumination(int N, int[][] lamps, int[][] queries) {
        var res = new List<int>();
        var st = new HashSet<int>(); // track lamp on/off
        var x = new Dictionary<int, int>();
        var y = new Dictionary<int, int>();
        var p = new Dictionary<int, int>();
        var q = new Dictionary<int, int>();
        foreach (var l in lamps) {
            int i = l[0], j = l[1];
            x[i] = x.GetValueOrDefault(i,0) + 1;
            y[j] = y.GetValueOrDefault(j,0) + 1;
            p[i+j] = p.GetValueOrDefault(i+j,0) + 1;
            q[i-j] = q.GetValueOrDefault(i-j,0) + 1;
            st.Add(i * N + j); // normalize i, j to track lamp
            // if N is big, => trank long as i << 32 | j for normalization 
            // since i is int32
            // var st = new HastSet<long>();
            // st.Add(i << 32 | j);
        }
        foreach (var qu in queries) {
            int i = qu[0], j = qu[1];
            if (x.ContainsKey(i)
                || y.ContainsKey(j)
                || p.ContainsKey(i + j)
                || q.ContainsKey(i - j)) {
                res.Add(1);
                for (int tx = i - 1; tx <= i + 1; ++tx) {
                    for (int ty = j - 1; ty <= j + 1; ++ty) {
                        if (tx < 0 || tx >= N || ty < 0 || ty >= N 
                           || !st.Contains(tx * N + ty)) continue;
                        st.Remove(tx * N + ty);
                        if (--x[tx] == 0) x.Remove(tx);
                        if (--y[ty] == 0) y.Remove(ty);
                        if (--p[tx + ty] == 0) p.Remove(tx + ty);
                        if (--q[tx - ty] == 0) q.Remove(tx - ty);
                   }
                }
            }
            else res.Add(0);
        }
        return res.ToArray();   
    }
}

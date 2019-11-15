public class Solution {
    public int[] ShortestAlternatingPaths(int n, int[][] red_edges, int[][] blue_edges) {
        var g = new Dictionary<Tuple<int, int>, List<int>>();   
        // red: 0, blue: 1
        for (int i = 0; i < red_edges.Length; i++) {
			var key = Tuple.Create(red_edges[i][0], 0);
            if (!g.ContainsKey(key)) 
                g.Add(key, new List<int>());
            g[key].Add(red_edges[i][1]);
        }
        for (int i = 0; i < blue_edges.Length; i++) {
			var key = Tuple.Create(red_edges[i][0], 1);
            if (!g.ContainsKey(key)) 
                g.Add(key, new List<int>());
            g[key].Add(blue_edges[i][1]);
        }
        var q = new Queue<Tuple<int, int>>();
        q.Enqueue(Tuple.Create(0,0));
        q.Enqueue(Tuple.Create(0,1));
        var res = new int[n, 2];
        for (int i= 0; i < n; i++) { res[i, 0] = n * 2;  res[i, 1] = n * 2; }
        while (q.Any()) {
            var t = q.Dequeue();
            if (!g.ContainsKey(t)) continue;
            foreach (var r in g[t]) {
                // t[1] is color
                if (res[r, 1 - t.Item2] == n * 2) {
                    res[r, 1 - t.Item2] = res[t.Item1, t.Item2] + 1;
                    q.Enqueue(Tuple.Create(r, 1 - t.Item2));
                }
            }
        }
        var ans = new int[n];
        for (int i= 0; i < n; i++) {
            var mn = Math.Min(res[i,0], res[i,1]);
            ans[i] = mn == n * 2 ? -1 : mn;
        }
        return ans;
    }
}

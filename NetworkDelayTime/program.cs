public class Solution {
    public int NetworkDelayTime(int[][] times, int N, int K) {
        int res = 0;
        var g = new Dictionary<int, List<int[]>>();
        for (int i = 1; i <= N; ++i) g.Add(i, new List<int[]>());
        foreach (var e in times) {
            g[e[0]].Add(new int[]{e[1], e[2]});
        } 
        int[] dist = new int[N+1];
        Array.Fill(dist, Int32.MaxValue);
        var q = new Queue<int>(); 
        q.Enqueue(K);
        dist[K] = 0;
        while(q.Any()) {
            var u = q.Dequeue();
            // BFS
            foreach (var e in g[u]) {
                int v = e[0], w = e[1];
                // visited u before
                // only update dist[v] if minize dist of v
                if (dist[u] != Int32.MaxValue && dist[u] + w < dist[v]) {
                    dist[v] = dist[u] + w;
                    // only calculate v if dist v is update
                    q.Enqueue(v);
                }
            }
        }
        for (int i = 1; i <= N; ++i) {
            res = Math.Max(res, dist[i]);
        }
        // O(E+V)
        return res == Int32.MaxValue ? -1 : res;
    }
}

public class Solution {
    public int[] ShortestAlternatingPaths(int n, int[][] red_edges, int[][] blue_edges) {
        var g = new Dictionary<string, List<int>>();   
        // red: 0, blue: 1
        for (int i = 0; i < red_edges.Length; i++) {
			var key =  0 + "-" + red_edges[i][0];
            if (!g.ContainsKey(key)) 
                g.Add(key, new List<int>());
            g[key].Add(red_edges[i][1]);
        }
        for (int i = 0; i < blue_edges.Length; i++) {
			var key =  1 + "-" + blue_edges[i][0];
            if (!g.ContainsKey(key)) 
                g.Add(key, new List<int>());
            g[key].Add(blue_edges[i][1]);
        }
        var q = new Queue<string>();
        q.Enqueue("0-0");
        q.Enqueue("1-0");
        var res = new int[n, 2];
        // init 0 => 0
        for (int i= 1; i < n; i++) { res[i, 0] = n * 2;  res[i, 1] = n * 2; }
        while (q.Any()) {
            var t = q.Dequeue();
            if (!g.ContainsKey(t)) continue;
	    // BFS => shortest path
            foreach (var r in g[t]) {
                int color = Int32.Parse(t.Split("-")[0]);
                int node  = Int32.Parse(t.Split("-")[1]);
                if (res[r, 1 - color] == n * 2) {
                    res[r, 1 - color] = res[node, color] + 1;
                    q.Enqueue((1-color) + "-" + r);
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

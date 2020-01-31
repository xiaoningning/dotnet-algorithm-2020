public class Solution {
    Dictionary<int, List<int>> g; // graph
    int[] times; // discovery time of each node
    int[] low; // earliest discovered time of node reachable from this node in DFS
    public IList<IList<int>> CriticalConnections(int n, IList<IList<int>> connections) {
        var res = new List<IList<int>>();
        g = new Dictionary<int, List<int>>();
        times = new int[n]; low = new int[n];
        Array.Fill(times, -1); Array.Fill(low, -1); 
        foreach (var c in connections) {
            if (!g.ContainsKey(c[0])) g.Add(c[0], new List<int>());
            if (!g.ContainsKey(c[1])) g.Add(c[1], new List<int>());
            g[c[0]].Add(c[1]);
            g[c[1]].Add(c[0]);
        }
        // Tarjan bridges algorithm
        dfs(0, -1, 0);
        foreach (var c in connections) {
            if (low[c[0]] > times[c[1]] || low[c[1]] > times[c[0]])
                res.Add(c);
        }
        // O(E+V)
        return res;
    }
    void dfs(int u, int parent, int t) {
        times[u] = t; low[u] = t;
        foreach (int i in g[u]) {
            if (i == parent) continue;
            // not visited
            if (times[i] == -1) {
                dfs(i, u, t + 1);
                low[u] = Math.Min(low[u], low[i]);
            }
            // i is visited => i is previous cycle
            else low[u] = Math.Min(low[u], times[i]);
            
        }
    }
}

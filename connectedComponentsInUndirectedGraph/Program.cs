public class Solution {
    public int CountComponents(int n, int[][] edges) {
        int res = 0;
        bool[] visited = new bool[n];
        Dictionary<int, List<int>> g = new Dictionary<int, List<int>>();
        foreach (var e in edges) {
            if (!g.ContainsKey(e[0])) g.Add(e[0], new List<int>());
            if (!g.ContainsKey(e[1])) g.Add(e[1], new List<int>());
            g[e[0]].Add(e[1]);
            g[e[1]].Add(e[0]);
        }
        for (int i = 0; i < n; ++i) {
            if (!visited[i]) {
                ++res;
                Dfs(g, visited, i);
            }
        }
        return res;
    }
    
    void Dfs(Dictionary<int, List<int>> g, bool[] v, int i) {
        if (v[i]) return;
        v[i] = true;
        if (!g.ContainsKey(i)) return;
        for (int j = 0; j < g[i].Count; ++j) {
            Dfs(g, v, g[i][j]);
        }
    }
    public int CountComponents1(int n, int[][] edges) {
        int[] root = new int[n];
        int res = n;
        for (int i = 0; i < n; i++) root[i] = i;
        foreach (var e in edges) {
            int x = GetRoot(root, e[0]), y = GetRoot(root, e[1]);
            if (x != y) {
                res--;
                root[x] = y;
            }
        }
        return res;
    }
    
    int GetRoot(int[] root, int i) {
        while (root[i] != i) {
            // path compression
            root[i] = root[root[i]];
            i = root[i];
        }
        return i;
    }
}

public class Solution {
    public int ReachableNodes(int[][] edges, int M, int N) {
        int[][] g = new int[N][];
        for (int i = 0; i < N; i++) {
            g[i] = new int[N];
            Array.Fill(g[i], -1);
        }
        foreach (var e in edges) {
            g[e[0]][e[1]] = e[2];
            g[e[1]][e[0]] = e[2];
        }
        int res = 0;
        bool[] visited = new bool[N];
        List<int[]> pq = new List<int[]>();
        pq.Add(new int[]{M, 0});
        while (pq.Any()) {
            int start = pq[0][1], move = pq[0][0];
            pq.RemoveAt(0);
            pq.OrderByDescending(x => x[0]);
            if (visited[start]) continue;
            visited[start] = true;
            res++; // add start node
            for (int i = 0; i < N; i++) {
                if (g[start][i] > -1) {
                    // only add pq with smaller move edge
                    if (move > g[start][i] && !visited[i]) {
                        pq.Add(new int[]{move - g[start][i] - 1, i});
                        pq.OrderByDescending(x => x[0]);
                    }
                    g[i][start] -= Math.Min(move, g[start][i]);
                    res += Math.Min(move, g[start][i]);
                }
            }
        }
        return res;
    }
}

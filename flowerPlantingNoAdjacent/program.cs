public class Solution {
    public int[] GardenNoAdj(int N, int[][] paths) {
        var G = new Dictionary<int, HashSet<int>>();
        for (int i = 0; i < N; i++) G.Add(i, new HashSet<int>());
        // bidirection
        foreach (var p in paths) {
            G[p[0] - 1].Add(p[1] - 1);
            G[p[1] - 1].Add(p[0] - 1);
        }
        int[] res = new int[N];
        for (int i = 0; i < N; i++) {
            int[] colors = new int[5];
            foreach (int j in G[i])
                colors[res[j]] = 1;
            for (int c = 4; c > 0; --c)
                // 0 not visited
                if (colors[c] == 0)
                    res[i] = c;
        }
        return res;
    }
}

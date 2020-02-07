public class Solution {
    public bool PossibleBipartition(int N, int[][] dislikes) {
        var g = new Dictionary<int, List<int>>();
        foreach (var d in dislikes) {
            if (!g.ContainsKey(d[0])) g.Add(d[0], new List<int>());
            if (!g.ContainsKey(d[1])) g.Add(d[1], new List<int>());
            g[d[0]].Add(d[1]);
            g[d[1]].Add(d[0]);
        }
        int[] roots = new int[N+1];        
        for (int i = 1; i <= N; i++) roots[i] = i;
        for (int i = 1; i <= N; i++) {
            if (!g.ContainsKey(i)) continue;
            int color1 = FindRoots(roots, i), color2 = FindRoots(roots,g[i][0]);
            if (color1 == color2) return false;
            for (int j = 1; j < g[i].Count; j++) {
                int color3 = FindRoots(roots, g[i][j]);
                if (color1 == color3) return false;
                roots[color3] = color2;
            }
        }
        return true;
    }
    int FindRoots(int[] roots, int x){
        return x == roots[x] ? x : FindRoots(roots, roots[x]);    
    }
    
    public bool PossibleBipartition1(int N, int[][] dislikes) {
        var g = new Dictionary<int, List<int>>();
        foreach (var d in dislikes) {
            if (!g.ContainsKey(d[0])) g.Add(d[0], new List<int>());
            if (!g.ContainsKey(d[1])) g.Add(d[1], new List<int>());
            g[d[0]].Add(d[1]);
            g[d[1]].Add(d[0]);
        }
        int[] colors = new int[N+1];
        var q = new Queue<int>();
        for (int i = 1; i <= N; i++) {
            if (colors[i] != 0) continue;
            colors[i] = 1;
            q.Enqueue(i);
            while(q.Any()) {
                int cur = q.Dequeue();
                if (!g.ContainsKey(cur)) continue;
                foreach (var nxt in g[cur]) {
                    if (colors[nxt] == colors[cur]) return false;
                    if (colors[nxt] == 0){
                      colors[nxt] = -1 * colors[cur];
                      q.Enqueue(nxt);  
                    } 
                }    
            }
        }
        return true;
    }
}

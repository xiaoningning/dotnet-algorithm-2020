public class Solution {
    public IList<int> FindMinHeightTrees(int n, int[][] edges) {
        if (n == 1) return new List<int>(){0};
        var adj = new Dictionary<int, HashSet<int>>();
        var q = new Queue<int>();
        for (int i = 0; i < n; i++) adj.Add(i, new HashSet<int>());
        for (int i = 0; i < edges.Length; i++) {
            adj[edges[i][0]].Add(edges[i][1]);
            adj[edges[i][1]].Add(edges[i][0]);
        }
        foreach (var a in adj) {
            if (a.Value.Count == 1) q.Enqueue(a.Key);
        }
        while (n > 2) {
            int size = q.Count;
            n -= size;
            for (int i = 0; i < size; i++) {
                var t = q.Dequeue();
                foreach (var a in adj[t]) {
                    adj[a].Remove(t);
                    if (adj[a].Count == 1) q.Enqueue(a);
                }
            }
        }
        return q.ToList();
    }
}

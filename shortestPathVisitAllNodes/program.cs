public class Solution {
    public int ShortestPathLength(int[][] graph) {
        int n = graph.Length, target = 0, res = 0;
        var visited = new HashSet<string>();
        var q = new Queue<int[]>();
        for (int i = 0; i < n; i++) {
            // bit mask to track if it is visited.
            int mask = 1 << i;
            target |= mask;
            visited.Add(mask.ToString() + "-" + i.ToString());
            q.Enqueue (new int[]{mask, i});
        }
        while (q.Count != 0) {
            // BFS for each level
            int size = q.Count;
            for (int i = 0; i < size; i++) {
                var cur = q.Dequeue();
                // path is edge, not node.
                if (cur[0] == target) return res;
                foreach (int next in graph[cur[1]]) {
                    int nMask = cur[0] | 1 << next;
                    string str = nMask.ToString() + "-" + next.ToString();
                    if (visited.Contains(str)) continue;
                    visited.Add(str);
                    q.Enqueue(new int[]{nMask, next});
                }
            }
            // path cnt = the cnt of edges, not nodes.
            res++;
        }
        return -1;
    }
}

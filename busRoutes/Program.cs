public class Solution {
    public int NumBusesToDestination(int[][] routes, int S, int T) {
        if (S == T) return 0;
        // key: stop, value:bus
        Dictionary<int,HashSet<int>> map = new Dictionary<int, HashSet<int>>();
        int m = routes.Length;
        for (int i = 0; i < m; i++){
            for (int j = 0; j < routes[i].Length; j++) {
                if (!map.ContainsKey(routes[i][j])) map.Add(routes[i][j], new HashSet<int>());
                map[routes[i][j]].Add(i);
            }
        }
        Queue<int> q = new Queue<int>();
        HashSet<int> visited = new HashSet<int>();
        q.Enqueue(S);
        int res = 0;
        while (q.Count != 0) {
            res++;
            int l = q.Count;
            for (int i = 0; i < l;  i++) {
                int t = q.Dequeue();
                var buses = map[t];
                foreach (int r in buses) {
                    if (visited.Contains(r)) continue;
                    visited.Add(r);
                    foreach (var s in routes[r]) {
                        if (s == T) return res;
                        else q.Enqueue(s);
                    }
            }
            }
            
        }
        return -1;
    }
}

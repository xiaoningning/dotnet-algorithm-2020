public class Solution {
    public int MinimumSemesters(int N, int[][] relations) {
        var m = new Dictionary<int,List<int>>();
        var indegree = new int[N+1];
        foreach(var r in relations) {
            indegree[r[1]]++;
            if (!m.ContainsKey(r[0])) m.Add(r[0],new List<int>());
            m[r[0]].Add(r[1]);
        }
        var q = new Queue<int>();
        for (int i = 1; i <= N; i++) if (indegree[i] == 0) q.Enqueue(i);
        int res = 0;
        while(q.Any()) {
            for (int size = q.Count; size > 0; size--) {
                var c = q.Dequeue(); N--;
                if (!m.ContainsKey(c)) continue;
                foreach (var k in m[c]) {
                    if (--indegree[k] == 0) q.Enqueue(k);
                }
            }
            res++;
        }
        return  N != 0 ? -1 : res;
    }
}

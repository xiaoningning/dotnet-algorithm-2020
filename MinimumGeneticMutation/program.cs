public class Solution {
    public int MinMutation(string start, string end, string[] bank) {
        var q = new Queue<string>();
        q.Enqueue(start);
        var visited = new HashSet<string>();
        visited.Add(start);
        int res = 0;
        while (q.Any()) {
            int cnt = q.Count;
            while (cnt-- > 0) {
                var cur = q.Dequeue();
                if (cur == end) return res;
                foreach (var nstr in bank) {
                    if (visited.Contains(nstr) || !ValidMutation(cur, nstr)) continue;
                    visited.Add(nstr);
                    q.Enqueue(nstr);
                }
            }
            res++;
        }
        return -1;
    }
    bool ValidMutation(string x, string y) {
        int cnt = 0;
        for (int i = 0; i < x.Length; i++) {
            if (x[i] != y[i]) cnt++;
            if (cnt > 1) return false;
        }
        return true;
    }
}

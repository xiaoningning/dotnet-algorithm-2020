public class Solution {
    public int OpenLock(string[] deadends, string target) {
        if (deadends.Contains("0000")) return -1;
        int res = 0;
        var visited = new HashSet<string>(){"0000"};
        var q = new Queue<string>(); q.Enqueue("0000");
        while (q.Any()) {
            ++res;
            for (int k = q.Count; k > 0; --k) {
                var t = q.Dequeue();
                for (int i = 0; i < t.Length; ++i) {
                    for (int j = -1; j <= 1; ++j) {
                        if (j == 0) continue;
                        var str = t.ToCharArray();
                        str[i] = (char)(((t[i] - '0') + 10 + j) % 10 + '0');
                        var s = new string(str);
                        if (s == target) return res;
                        if (!visited.Contains(s) && !deadends.Contains(s)) 
                            q.Enqueue(s);        
                        visited.Add(s);
                    }
                }
            } 
        }
        return -1;
    }
}

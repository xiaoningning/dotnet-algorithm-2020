public class Solution {
    public int KSimilarity(string A, string B) {
        int res = 0, n = A.Length;
        var visited = new HashSet<string>(){A};
        var q = new Queue<string>();
        q.Enqueue(A);
        while (q.Any()) {
            int cnt = q.Count;
            // BFS => minimal
            while (cnt-- > 0) {
                string cur = q.Dequeue();
                if (cur == B) return res;
                int i = 0;
                while (i < n && cur[i] == B[i]) i++;
                for (int j = i+1; j < n; j++) {
                    // cur[j] == B[j] => no need to swap
                    // cur[j] != B[i] at i => still not the same after swap
                    if (cur[j] == B[j] || cur[j] != B[i]) continue;
                    cur = Swap(cur, i, j);
                    if (!visited.Contains(cur)) {
                        visited.Add(cur);
                        q.Enqueue(cur);
                    }
                    cur = Swap(cur, i, j);
                }
            }
            res++;
        }
        return -1;
    }
    string Swap(string s, int i, int j) {
        var arr = s.ToCharArray();
        char t = arr[i];
        arr[i] = arr[j]; 
        arr[j] = t;
        return new string(arr);
    }
}

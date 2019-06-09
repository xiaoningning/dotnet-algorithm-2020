public class Solution {
    public int FindCircleNum(int[][] M) {
        int n = M.GetLength(0);
        int res = 0;
        bool[] visited = new bool[n];
        var q = new Queue<int>();
        for (int i = 0; i < n; i++) {
            if (visited[i]) continue;
            q.Enqueue(i);
            while (q.Count != 0) {
                var t = q.Dequeue();
                visited[t] = true;
                for (int j = 0; j < n; j++) {
                    if (M[t][j] != 1 || visited[j]) continue;
                    else q.Enqueue(j);
                }
            }
            res++;
        }
        return res;
    }
    
    public int FindCircleNum1(int[][] M) {
        int n = M.GetLength(0);
        int[] root = new int[n];
        int res = n;
        for (int i = 0; i < n; i++) root[i] = i;
        for (int i = 0; i < n; i++) {
            for (int j = i + 1; j < n; j++) {
                if (M[i][j] == 1) {
                    int p1 = GetRoot(root, i);
                    int p2 = GetRoot(root, j);
                    if (p1 != p2) {
                        --res;
                        root[p2] = p1;
                    }
                }
            }   
        }
        return res;
    }

    int GetRoot(int[] root, int i) {
        while (root[i] != i) {
            // path compression
            root[i] = root[root[i]];
            i = root[i];
        }
        return i;
    }
}

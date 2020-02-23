public class Solution {
    public int ShortestBridge(int[][] A) {
        int m = A.Length, n = A[0].Length;
        var q = new Queue<int>();
        // find && mark 1st island as 2
        bool found = false;
        for (int i = 0; !found && i < m; ++i)
            for (int j = 0; !found && j < n; ++j) 
                if (A[i][j] == 1) found = dfs(A, i, j, q);
        
        int res = 0;
        var dirs = new int[,]{{0,1}, {1,0}, {0,-1}, {-1,0}};
        // BFS to expand 1st island
        while (q.Any()){
            int size = q.Count;
            while (size-- > 0) {
                int t = q.Dequeue();
                int x = t / n, y = t % n;
                for (int k = 0; k < 3; k++) {
                    int nx = x + dirs[k,0], ny = y + dirs[k,1];
                    if (nx < 0 || ny < 0 || nx >= m || ny >= n || A[nx][ny] == 2) continue;
                    if (A[nx][ny] == 1) return res;
                    A[nx][ny] = 2;
                    q.Enqueue(nx * n + ny);
                }
            }
            res++;
        }        
        return -1;
    }
    
    bool dfs(int[][] A, int i, int j, Queue<int> q) {
        if (i < 0 || j < 0 || i >= A.Length || j >= A[0].Length || A[i][j] != 1) return false;
        A[i][j] = 2;
        q.Enqueue(i * A.Length + j);
        dfs(A, i-1, j, q); 
        dfs(A, i, j-1, q); 
        dfs(A, i+1, j, q);                 
        dfs(A, i, j+1, q);
        return true;
    }
}

public class Solution1 {
    public int ShortestBridge(int[][] A) {
        int m = A.Length, n = A[0].Length, cnt = 2;
        // find && mark 1st island as 2
        bool found = false;
        for (int i = 0; !found && i < m; ++i)
            for (int j = 0; !found && j < n; ++j) 
                found = dfs(A, i, j, cnt);
        
        int res = 0;
        // BFS to expand 1st island
        while (cnt < n * m){
            for (int i = 0; i < m; ++i) {
                for (int j = 0; j < n; ++j) {
                    if (A[i][j] == cnt
                        && (expand(A, i-1, j, cnt) || expand(A, i, j-1, cnt) || expand(A, i+1, j, cnt) || expand(A, i, j+1, cnt))) 
                        return cnt - 2;
                }
            }
            cnt++;
        }        
        return -1;
    }
    
    bool expand(int[][] A, int i, int j, int cnt) {
        if (i < 0 || j < 0 || i >= A.Length || j >= A[0].Length) return false;
        if (A[i][j] == 0) A[i][j] = cnt + 1;
        return A[i][j] == 1;
    }
    
    bool dfs(int[][] A, int i, int j, int cnt) {
        if (i < 0 || j < 0 || i >= A.Length || j >= A[0].Length || A[i][j] != 1) return false;
        A[i][j] = cnt;
        dfs(A, i-1, j, cnt); 
        dfs(A, i, j-1, cnt); 
        dfs(A, i+1, j, cnt);                 
        dfs(A, i, j+1, cnt);
        return true;
    }
}

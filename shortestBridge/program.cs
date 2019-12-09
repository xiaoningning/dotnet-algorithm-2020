public class Solution {
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

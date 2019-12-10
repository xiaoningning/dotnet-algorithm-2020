public class Solution {
    int[] root; // root
    int n, cnt;
    public int RegionsBySlashes1(string[] grid) {
        n = grid.Length;
        // split grid as 4 regions,
        // as 0,1,2,3 <= (top, left, buttom, right)
        // if /,/,\,\, then 4, if missing one / or \, union them.
        cnt = n * n * 4; 
        root = new int[cnt];
        // init root
        for (int i = 0; i < n * n * 4; ++i) root[i] = i;
        for (int i = 0; i < n; ++i) {
            for (int j = 0; j < n; ++j) {
                // if i/j > 0, union with the previous neighbor regions
                if (i > 0) union(g(i - 1, j, 2), g(i, j, 0));
                if (j > 0) union(g(i , j - 1, 1), g(i , j, 3));
                // if empty, then union all of them
                if (grid[i][j] != '/') {
                    union(g(i , j, 0), g(i , j,  1));
                    union(g(i , j, 2), g(i , j,  3));
                }
                if (grid[i][j] != '\\') {
                    union(g(i , j, 0), g(i , j,  3));
                    union(g(i , j, 2), g(i , j,  1));
                }
            }
        }
        return cnt;
    }
    // normalize idx. k {0,1,2,3}
    int g(int i, int j, int k) {
        return (i * n + j) * 4 + k;
    }
    void union(int x, int y) {
        x = find(x); y = find(y);
        if (x != y) {
            // connected then reduce cnt
            root[x] = y; cnt--;
        }
    }
    int find(int x) {
        if (x != root[x]) root[x] = find(root[x]);
        return root[x];
    }
    
    //DFS
    public int RegionsBySlashes(string[] grid) {
        int n = grid.Length, m = grid[0].Length;
        int res = 0;
        // >=3 to 1 represent /, \
        // every 1 seperates by 00
        // b/s you want h/v 4 directions connected
        // if sperates by 0, then h/v dirs has no connected.
        // => 0/1 island problem
        int[,] g = new int[n*3,m*3];
        for(int i = 0;i < n; i++){
            for(int j = 0; j < m; j++){
                if(grid[i][j] == '/'){
                    g[i * 3,j * 3 + 2] = 1;
                    g[i * 3 + 1, j * 3 + 1] = 1;
                    g[i * 3 + 2, j * 3] = 1;
                }
                else if(grid[i][j]=='\\'){
                    g[i * 3, j * 3] = 1;
                    g[i * 3 + 1, j * 3 + 1] = 1;
                    g[i * 3 + 2, j * 3 + 2] = 1;
                }
                // if empty, then it is 0 and no 1
            }
        }
        for(int i = 0; i < g.GetLength(0); i++){
            for(int j = 0; j < g.GetLength(1); j++){
                if(g[i, j]==0){
                    // connect all islands by 0
                    // count 0 as one region
                    dfs(g,i,j);
                    res++;
                }
            }
        }
        return res;
    }
    void dfs(int[,] g, int i, int j) {
        int n = g.GetLength(0), m = g.GetLength(1);
        if (i < 0 || i >= n || j < 0 || j >= m || g[i, j]==1) return;
        g[i, j] = 1;
        int[] d = new int[]{0,-1,0,1,0};
        for(int k = 0; k < 4; k++){
            dfs(g, i + d[k], j + d[k+1]);
        }
    }
}

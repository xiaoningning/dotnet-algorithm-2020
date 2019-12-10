public class Solution {
    int[] root; // root
    int n, cnt;
    public int RegionsBySlashes(string[] grid) {
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
}

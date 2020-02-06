public class Solution {
    public int[] FindRedundantConnection(int[][] edges) {
        int size = edges.Length;
        var uf = new UnionFind(size);
        foreach (var e in edges)
            if (!uf.Union(e[0], e[1])) return e;
        // weighted union find with path compression
        // check if u and v is connected, => O(logn => O(1))
        // O(n* logn) => O(n)
        return new int[2];
    }
    
    public class UnionFind {
        int[] _roots;
        int[] _ranks;
        // node is 1 ~ n
        public UnionFind(int n) {
            _roots = new int[n+1];
            _ranks = new int[n+1];
            for (int i = 0; i < n; i++) _roots[i] = i;
        }
        // Merge sets that contains u and v.
        // Return true if merged
        // false if u and v are already in one set.
        public bool Union(int u, int v) {
            int ru = FindRoots(u);
            int rv = FindRoots(v);
            if (ru == rv) return false;
            // Meger low rank tree into high rank tree
            if (_ranks[rv] > _ranks[ru]) _roots[ru] = rv;
            else if (_ranks[ru] > _ranks[rv]) _roots[rv] = ru;
            else {
                _roots[rv] = ru;
                _ranks[rv]++;
            }
            return true;
        }
        // get roots
        int FindRoots(int x) {
            // path compression
            return x == _roots[x] ? x : FindRoots(_roots[x]);
        }
    }
    
    public int[] FindRedundantConnection1(int[][] edges) {
        int size = edges.Length;
        int[] roots = new int[size + 1];
        for(int i = 0; i < roots.Length; i++){
            roots[i] = i;
        }
        
        // undirected graph
        for(int i = 0; i < edges.GetLength(0); i++){
            int x0 = edges[i][0], x1 = edges[i][1];
            // find the common root
            if (FindRoot(roots, x0) == FindRoot(roots, x1)) {
                return new int[]{x0, x1};
            }
            else{
                // update root since x0,x1 is connected
                roots[FindRoot(roots, x0)] = FindRoot(roots, x1);
            }
        }
        return new int[2];
    }
    int FindRoot(int[] roots, int i){
        while(i != roots[i]) {
            // path compression
            roots[i] = roots[roots[i]];
            i = roots[i];
        }
        return i;
    }
}

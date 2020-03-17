public class Solution {
    public int MinimumCost(int N, int[][] connections) {
        Array.Sort(connections, (a,b) => a[2] - b[2]); // sort by cost
        int res = 0;
        var uf = new UnionFind(N);
        foreach(var c in connections)
            if(uf.Union(c[0]-1, c[1]-1)) res += c[2];
        // O(NlogN)
        // Union Find takes O(1)
        // Note that Union operation takes constant time 
        // when UnionFind is implemented with 
        // both path compression and union by rank.
        return uf.GetSize() == 1 ? res : -1;
    }
}
public class UnionFind {
    int size;
    int[] roots;
    int[] ranks;
    public UnionFind(int n) {
        roots = new int[n];
        for (int i = 0; i < n; i++) roots[i] = i;
        ranks = new int[n];
        size = n;
    }
    public bool Union(int i, int j) {
        int ri = FindRoot(i), rj = FindRoot(j);
        if (ri != rj) {
            size--;
            if (ranks[rj] < ranks[rj]) roots[rj] = ri;
            else if (ranks[ri] < ranks[rj]) roots[ri] = rj;
            else {
                roots[ri] = rj;
                ranks[rj] += 1;
            }
            return true;
        }
        else return false;
    }
    int FindRoot(int x) {
        // path compression
        while(roots[x] != x) x = roots[x] = roots[roots[x]];
        return x;
    }
    /*
    // another path compression implementation
    int FindRoot(int x) {
        return x == FindRoot(x) ? x : FindRoot(roots[x]);
    }
    */
    public int GetSize() { return size; }
}

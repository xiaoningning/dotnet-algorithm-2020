public class Solution {
    public int NumSimilarGroups(string[] A) {
        int n = A.Length;
        var g = new UnionFind(n);
        for (int i = 0; i < n; i++) {
            for (int j = i + 1; j < n; j++) {
                if (IsSimilar(A[i], A[j])) g.Union(i,j);
            }
        }
        return g.GetSize();
    }
    bool IsSimilar(string a, string b) {
        int cnt = 0;
        for (int i = 0; i < a.Length; i++) {
            if (a[i] != b[i] && ++cnt > 2) return false;
        }
        return true;
    }
}

public class UnionFind {
    int size;
    int[] root;
    public UnionFind(int n) {
        root = new int[n];
        size = n;
        for (int i = 0; i < n; i++) root[i] = i;
    }
    public void Union(int i, int j) {
        int ri = Find(i), rj = Find(j);
        if (ri != rj) {
            root[ri] = rj;
            size--;
        }
    }
    int Find(int x) {
        while(root[x] != x) {
            // path compression
            root[x] = root[root[x]];
            x = root[x];
        }
        return x;
    }
    public int GetSize() { return size;}
}

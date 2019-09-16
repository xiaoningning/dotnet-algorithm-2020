public class Solution {
    // https://www.jianshu.com/u/9ab55d00c1f6
    // treat stone with same row or column as island
    // stone with same row or column
    int islands = 0;
    // m: root map of a graph
    Dictionary<int, int> m = new Dictionary<int, int>();
    public int RemoveStones1(int[][] stones) {
        for (int i =0; i < stones.Length; i++) {
            // int as index for x
            // bitwise ~int as index for y
            Union(stones[i][0], ~stones[i][1]);
        }
        return stones.Length - islands;
    }
    // union and find in graph
    void Union(int x, int y) {
        x = FindRoot(x);
        y = FindRoot(y);
        // stone with the same col or row
        // x or y can be the same root
        if (m.ContainsKey(x) && m[x] != y) {
            m[x] = y;
            islands--;
        }
    }
    int FindRoot(int x) {
        if (!m.ContainsKey(x))  {
            m.Add(x, x);
            islands++;
        }
        if (m[x] != x) {
            // update root of a graph
            m[x] = FindRoot(m[x]);
        }
        return m[x];
    }
    
    int cnt = 0;
    Dictionary<string, string> roots = new Dictionary<string, string>();
    public int RemoveStones(int[][] stones){
        for (int i = 0; i < stones.Length; i++) {
            for (int j = 0; j < stones.Length; j++) {
                if (stones[i][0] == stones[j][0] || stones[i][1] == stones[j][1]){
                    UnionFind(stones[i], stones[j]);
                }
            }
        }
        return stones.Length - cnt;
    }
    void UnionFind(int[] i, int[] j) {
        string t1 = i[0] + "-" + i[1];
        string t2 = j[0] + "-" + j[1];
        string x = FindRoot(t1);
        string y = FindRoot(t2);
        if (roots.ContainsKey(x) && roots[x] != y) {
            roots[x] = y;
            cnt--;
        }
    }
    string FindRoot(string i) {
        if (!roots.ContainsKey(i)) {
            roots.Add(i,i);
            cnt++;
        }
        if (roots[i] != i) roots[i] = FindRoot(roots[i]);
        return roots[i];
    }
}

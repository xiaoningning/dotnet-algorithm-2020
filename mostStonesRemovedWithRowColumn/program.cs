public class Solution {
    // https://www.jianshu.com/u/9ab55d00c1f6
    // treat stone with same row or column as island
    // stone with same row or column
    int islands = 0;
    // m: root map of a graph
    Dictionary<int, int> m = new Dictionary<int, int>();
    public int RemoveStones(int[][] stones) {
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
            // update root of graph
            m[x] = FindRoot(m[x]);
        }
        return m[x];
    }
}

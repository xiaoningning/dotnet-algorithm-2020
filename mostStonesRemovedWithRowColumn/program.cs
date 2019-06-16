public class Solution {
    // treat stone with same row/column as island
    // stone with same row/column
    int islands = 0;
    // m: root mapg of a graph
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
        x = Find(x);
        y = Find(y);
        if (m.ContainsKey(x) && m[x] != y) {
            m[x] = y;
            islands--;
        }
    }
    int Find(int x) {
        if (!m.ContainsKey(x))  {
            m.Add(x, x);
            islands++;
        }
        if (m[x] != x) {
            // update root of graph
            m[x] = Find(m[x]);
        }
        return m[x];
    }
}

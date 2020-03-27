public class Solution {
    public int FindLongestChain(int[][] pairs) {
        Array.Sort(pairs, (a,b) => a[1] - b[1]);
        var st = new HashSet<int[]>();
        foreach (var p in pairs) {
            if (!st.Any()) st.Add(p);
            else {
                if (st.Last()[1] < p[0]) st.Add(p);
            }
        }
        return st.Count;
    }
}

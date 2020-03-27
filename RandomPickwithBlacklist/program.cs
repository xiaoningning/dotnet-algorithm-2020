public class Solution {
    int len = 0;
    Random r = new Random();
    Dictionary<int, int> m = new Dictionary<int,int>();
    public Solution(int N, int[] blacklist) {
        len = N - blacklist.Length;
        foreach (var b in blacklist) m[b] = -1;
        // remap b to non black list number
        foreach (var b in blacklist) {
            if (b < len)  {
                while (m.ContainsKey(N - 1)) N--;
                m[b] = N - 1;
                N--;
            }
        }
    }
    
    public int Pick() {
        int p = r.Next(len);
        return m.ContainsKey(p) ? m[p] : p;
    }
}

/**
 * Your Solution object will be instantiated and called as such:
 * Solution obj = new Solution(N, blacklist);
 * int param_1 = obj.Pick();
 */

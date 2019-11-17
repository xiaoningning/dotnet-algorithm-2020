public class Solution {
    public int LongestSubsequence(int[] arr, int difference) {
        var m = new Dictionary<int,int>();
        int res = 0;
        foreach (int a in arr) {
            m[a] = m.GetValueOrDefault(a-difference, 0) + 1;
            res = Math.Max(m[a],res);
        }
        return res;
    }
}

public class Solution {
    public int FindPairs(int[] nums, int k) {
        var m = new Dictionary<int, int>();
        foreach (var n in nums) {
            if (!m.ContainsKey(n)) m.Add(n, 0);
            m[n]++;
        }
        int res = 0;
        foreach (var i in m.Keys) {
            // no i-k, => it will over count
            if ((k > 0 && m.ContainsKey(i+k))
               || (k == 0 && m[i] > 1)) res++;
        }
        return res;
    }
}

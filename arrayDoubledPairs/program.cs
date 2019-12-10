public class Solution {
    public bool CanReorderDoubled(int[] A) {
        var cnt = new SortedDictionary<int, int>();
        foreach (int a in A) {
            if (!cnt.ContainsKey(a)) cnt.Add(a,0);
            cnt[a]++;
        }
        var keys = cnt.Keys.ToList();
        foreach (int x in keys) {
            // after t update, skip cnt 0
            if (cnt[x] == 0) continue;
            int t = x < 0 ? x / 2 : x * 2;
            // reorder => A[2 * i + 1] = 2 * A[2 * i]
            if (x < 0 && x % 2 != 0 
               || !cnt.ContainsKey(t)
               || cnt[x] > cnt[t]) return false;
            cnt[t] -= cnt[x];
        }
        // O(NlogK)
        return true;
    }
}

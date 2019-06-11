public class Solution {
    public int TotalFruit(int[] tree) {
        // longest string with 2 distinct
        var m = new Dictionary<int, int>();
        int res = 0, left = 0;
        for (int i = 0; i < tree.Length; i++) {
            if (!m.ContainsKey(tree[i])) m.Add(tree[i],0);
            m[tree[i]]++;
            while (m.Count() > 2) {
                if (--m[tree[left]] == 0) m.Remove(tree[left]);
                ++left;
            }
            res = Math.Max(res, i - left + 1);
        }
        return res;
    }
}

public class Solution {
    List<int> res = new List<int>();
    public IList<int> SplitIntoFibonacci(string S) {
        Helper(S, 0);
        return res;
    }
    bool Helper(string s, int idx) {
        if ( idx == s.Length && res.Count >= 3) return true;
        for (int i = idx; i < s.Length; i++) {
            string cur = s.Substring(idx, i - idx + 1);
            if ((cur.Length > 1 && cur[0] == '0') || cur.Length > 10) break;
            long num = long.Parse(cur);
            if (num > Int32.MaxValue) break;
            int size = res.Count;
            // early termination
            if (size >= 2 && num > res[size-1] + res[size-2]) break;
            if (size <= 1 || num == res[size-1] + res[size-2]) {
                res.Add((int)num);
                // branch pruning. 
                // if one branch has found fib seq, return true to upper call
                if (Helper(s, i + 1)) return true;
                res.RemoveAt(res.Count - 1);
            }
        }
        return false;
    }
}

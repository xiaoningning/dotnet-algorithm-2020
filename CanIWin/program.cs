public class Solution {
    public bool CanIWin(int maxChoosableInteger, int desiredTotal) {
        if (maxChoosableInteger >= desiredTotal) return true;
        if ((maxChoosableInteger + 1) * maxChoosableInteger / 2 < desiredTotal) return false;
        var m = new Dictionary<int, bool>();
        return CanIWin(maxChoosableInteger, desiredTotal, 0, m);
    }
    bool CanIWin(int len, int total, int used, Dictionary<int, bool> m){
        if (m.ContainsKey(used)) return m[used];
        for (int i = 1; i <= len; i++) {
            int mask = 1 << i;
            // i not used
            if ((mask & used) == 0) {
                // next player false
               if(total <= i || !CanIWin(len, total - i, mask|used,m) ) {
                    m[used] = true;
                    return m[used];
                }
            }
        }
        m[used] = false;
        return m[used];
    }
}

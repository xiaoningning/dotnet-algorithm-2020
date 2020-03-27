public class Solution {
    public bool CheckRecord(string s) {
        int cntA = 0, cntL = 0;
        foreach (var c in s) {
            if (c == 'A') {
                if (++cntA > 1) return false;
                cntL = 0;
            }
            else if (c == 'L') {
                if (++cntL > 2) return false;
            }
            else cntL = 0;
        }
        return true;
    }
}

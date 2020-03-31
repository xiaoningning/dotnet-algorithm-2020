public class Solution {
    public bool CanWin(string s) {
        for (int i = 1; i < s.Length; i++) {
            if (s[i] == '+' && s[i-1] == '+' 
                && !CanWin(s.Substring(0, i - 1) + "--" + s.Substring(i+1))) return true;
        }
        return false;
    }
}

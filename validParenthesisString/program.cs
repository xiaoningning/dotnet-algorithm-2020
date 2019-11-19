public class Solution {
    public bool CheckValidString(string s) {
        return Helper(s, 0, 0);
    }
    bool Helper(string s, int i, int opened) {
        if (i == s.Length) return opened == 0;
        // no ( before )
        if (s[i] == '(') return opened < 0 ? false : Helper(s, i+1, opened+1);
        else if (s[i] == ')') return Helper(s, i+1, opened-1);
        // * case => ( or ) or ""
        else return Helper(s, i+1, opened+1) || Helper(s, i+1, opened-1) || Helper(s, i+1, opened);
    }
}

public class Solution {
    public string LongestPalindrome(string s) {
        if (s.Length < 2) return s;
        int n = s.Length, maxLen = 0, start = 0;
        for (int i = 0; i < n; i++) {
            searchPanlindrome(s, i, i, ref start, ref maxLen);
            searchPanlindrome(s, i, i+1, ref start, ref maxLen);
        }
        return s.Substring(start, maxLen);
    }
    void searchPanlindrome(string s, int left, int right, ref int start, ref int maxLen){
        while (left >=0 && right < s.Length && s[left] == s[right]) {
            left--; right++;
        }
        if (maxLen < right - left - 1) {
            start = left + 1;
            maxLen = right - left - 1;
        }
    }
}

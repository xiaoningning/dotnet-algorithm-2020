public class Solution {
    public string LongestPalindrome(string s) {
        if (s.Length < 2) return s;
        // maxlen = 1: handle "ac" -> "a"
        int n = s.Length, maxLen = 1, start = 0;
        bool[,] dp = new bool[n,n];
        for (int i = 0; i < n; i++) {
            dp[i,i] = true;
            for (int j = 0; j < i; j++) {
                dp[j,i] = s[i] == s[j] && (dp[j+1,i-1] || i == j + 1);
                if (dp[j,i] && i-j+1 > maxLen) {
                    maxLen = i-j+1;
                    start = j;
                }
            }
        }
        return s.Substring(start, maxLen);
    }
    
    public string LongestPalindrome1(string s) {
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
            maxLen = right - (left + 1);
        }
    }
}

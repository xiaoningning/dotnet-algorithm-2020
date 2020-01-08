public class Solution {
    public string LongestPalindrome1(string s) {
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
    
    public string LongestPalindrome(string s) {
        if (s.Length < 2) return s;
        int n = s.Length, maxLen = 1, start = 0;
        for (int i = 0; i < n; i++) {
            int cur = Math.Max(getLen(s, i, i), getLen(s, i, i+1));
            if (cur > maxLen) {
                start = i - (cur - 1) / 2;
                maxLen = cur;
            }
        }
        // O(n^2)
        return s.Substring(start, maxLen);
    }
    int getLen(string s, int left, int right){
        while (left >=0 && right < s.Length 
               && s[left] == s[right]) {
            left--; right++;
        }
        // extra --/++ => -1
        return right - left - 1;
    }
}

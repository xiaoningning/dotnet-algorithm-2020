using System;

namespace minWindowSubsequence
{
    class Program
    {
        static void Main(string[] args)
        {
            var obj = new Solution();
            string s = "abcdebdde";
            string t = "bde";
            Console.WriteLine("Min Window Subsequence {0}", obj.MinWindow(s, t));
        }
    }
    public class Solution {
        public string MinWindow(string S, string T) {
            int m = S.Length, n = T.Length, minLen = Int32.MaxValue;
            string res = "";
            int[,] dp = new int[m + 1, n + 1];
            for (int i = 0 ; i <= m; i++){
                for (int j = 0 ; j <= n; j++) {
                    dp[i, j] = -1;
                }
            }
            for (int i = 0; i <= m; ++i) dp[i, 0] = i;
            for (int i = 1; i <= m; i++) {
                for (int j = 1; j <= Math.Min(i, n); j++) {
                    dp[i, j] = (S[i - 1] == T[j - 1]) ? dp[i - 1, j - 1] : dp[i - 1, j];
                }
                if (dp[i, n] != -1) {
                    int len = i - dp[i, n];
                    if (minLen > len) {
                        minLen = len;
                        res = S.Substring(dp[i, n], minLen);
                    }
                }
            }
            return res;            
        }

        public string MinWindow(string S, string T) {
            int m = S.Length, n = T.Length, minLen = Int32.MaxValue;
            int i = 0, j = 0;
            string res = "";
            while (i < m) {
                if (S[i] == T[j]) {
                    if (j == n - 1) {
                        int end = i;
                        while (--j >= 0) {
                            while (S[--i] != T[j]);
                        }                        
                        if (end - i  + 1 < minLen) {
                            minLen = end - i + 1;
                            res = S.Substring(i, minLen);
                        }
                    }
                    ++j;
                }
                ++i;
            }
            return res;            
        }
    }
}

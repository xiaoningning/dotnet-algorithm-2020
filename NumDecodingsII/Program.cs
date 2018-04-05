using System;

namespace NumDecodingsII
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("input string: {0}", args[0]);
            Console.WriteLine("numbers of decoding: {0}", NumDecodings2(args[0]));
        }

        static int NumDecodings(string s) {
            long M = (long)(1e9 + 7);
            int n = s.Length;
            if( n == 0 || string.IsNullOrEmpty(s)) return 0;
            long[] dp = new long[n + 1];
            dp[0] = 1;
            dp[1] = Ways(s[0]);
            for (int i = 2; i <= n; i++){
                if (s[i-1] == '0'){
                    if (s[i - 2] == '1' || s[i - 2] == '2') {
                        dp[i] += dp[i - 2];
                    } 
                    else if (s[i - 2] == '*') {
                        dp[i] += 2 * dp[i - 2];
                    }
                }
                else if (s[i-1] >= '1'){
                    dp[i] += dp[i - 1];
                    if (s[i - 2] == '1' || (s[i - 2] == '2' && s[i-1] <= '6')) {
                        dp[i] += dp[i - 2];
                    } 
                    else if (s[i - 2] == '*') {
                        dp[i] += (s[i - 1] <= '6') ? (2 * dp[i - 2]) : dp[i - 2];
                    } 
                }
                else if (s[i-1] == '*'){
                    dp[i] += 9 * dp[i-1];
                    if (s[i - 2] == '1') dp[i] += 9 * dp[i - 2];
                    else if (s[i - 2] == '2') dp[i] += 6 * dp[i - 2];
                    else if (s[i - 2] == '*') dp[i] += 15 * dp[i - 2];
                }
                dp[i] %= M;
            }
            return (int)dp[n];
        }

        private static int Ways(int ch) {
            if(ch == '*') return 9;
            if(ch == '0') return 0;
            return 1;
        }

        static int NumDecodings2(string s) {
            long M = (long)(1e9 + 7);
            long e0 = 1, e1 = 0, e2 = 0, f0, f1, f2;
            foreach (char c in s.ToCharArray()) {
                if (c == '*') {
                    f0 = 9 * e0 + 9 * e1 + 6 * e2;
                    f1 = e0;
                    f2 = e0;
                } else {
                    f0 = ((c > '0') ? e0 : 0) + e1 + ((c <= '6') ? e2 : 0);
                    f1 = (c == '1') ? e0 : 0;
                    f2 = (c == '2') ? e0 : 0;
                }
                e0 = f0 % M;
                e1 = f1;
                e2 = f2;
            }
            return (int)e0;
        }
    }
}

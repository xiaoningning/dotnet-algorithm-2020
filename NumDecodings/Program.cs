using System;

namespace NumDecodings
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("input string: {0}", args[0]);
            Console.WriteLine("numbers of decoding: {0}", NumDecodings(args[0]));
        }

        static int NumDecodings(string s) {
            int n = s.Length;
            if( n == 0 || string.IsNullOrEmpty(s)) return 0;
            int[] dp = new int[n + 1];
            dp[0] = 1;
            for (int i = 1; i <= n; i++){
                dp[i] = s[i-1] == '0' ? 0 : dp[i-1];
                if ( i >= 2 && (s[i-2] == '1' || (s[i-2] == '2' && s[i-1] <= '6')) ) dp[i] += dp[i - 2];
            }
            return dp[n];
        }
    }
}

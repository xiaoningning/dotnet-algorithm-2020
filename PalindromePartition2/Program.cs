using System;

namespace PalindromePartition2
{
    class Program
    {
        static void Main(string[] args)
        {
            var obj = new Solution();
            Console.WriteLine("Palindrome MinCut: {0}", obj.MinCut("aab"));
        }
    }
    public class Solution {
        public int MinCut(string s) {
            int n = s.Length;
            // number of cuts for the first k characters
            int[] dp = new int[n+1];
            for(int i = 0; i <= n; i++) dp[i] = i-1; // max cuts
            for(int i = 0; i < n; i++){
                // odd length palindrome: xyx
                for(int j = 0; i-j>=0 && i+j < n && s[i+j] == s[i-j]; j++)
                    dp[i+j+1]=Math.Min(dp[i+j+1], 1+dp[i-j]);
                // even length palindrome: xx
                for(int j = 1; i-j+1>=0 && i+j < n && s[i+j] == s[i-j+1]; j++)
                    dp[i+j+1]=Math.Min(dp[i+j+1], 1+dp[i-j+1]);
            }
            return dp[n];
        }
    }
}

using System;

namespace wildcardMatching
{
    class Program
    {
        static void Main(string[] args)
        {
            var obj = new Solution();
            Console.WriteLine("wild card match:{0}", obj.IsMatch("aab", "?*"));
        }
    }
    public class Solution {
         // '?' Matches any single character.
         // '*' Matches any sequence of characters (including the empty sequence).
         public bool IsMatch(string s, string p){
            bool[,] dp = new bool[s.Length + 1, p.Length + 1];
            dp[0,0] = true;         
            // s = "", p = "*"
            // i start as 0
            for (int i = 0; i <= s.Length; i++){
                for (int j = 1; j <= p.Length; j++){
                    if (p[j-1] == '*'){
                        dp[i,j] = dp[i, j-1] || (i > 0 && dp[i-1,j]);
                    }
                    else {
                        dp[i,j] = i > 0 && dp[i-1, j-1] && (s[i-1] == p[j-1] || p[j-1] == '?');
                    }
                }
            }
            return dp[s.Length, p.Length];
        }

        public bool IsMatch1(string s, string p) {
            int si = 0, pi = 0, sstar = -1, pstar= -1;
            // s = "", then go after while directly
            while (si < s.Length){
                if (pi < p.Length && (p[pi] == '?' || s[si] == p[pi])){
                    si++;
                    pi++;
                }
                else if (pi < p.Length && p[pi] == '*'){
                    pstar = pi;
                    sstar = si;
                    // it might be > 1 *
                    // p = "*"
                    pi++;
                }
                else if (pstar != -1){
                    pi = pstar + 1;
                    sstar++;
                    si = sstar;
                }
                else return false;

            }
            // s = "", p = "*"
            while (pi < p.Length && p[pi] == '*') pi++;
            return pi == p.Length;
        }
    }
}

using System;

namespace rexMatching
{
    class Program
    {
        static void Main(string[] args)
        {
            var obj = new Solution();
            Console.WriteLine("regular expression match:{0}", obj.IsMatch1("aa", "a*"));
        }

        //'.' Matches any single character.
        // '*' Matches zero or more of the preceding element.
        public class Solution {
            public bool IsMatch(string s, string p) {
                if (string.IsNullOrEmpty(p)) return string.IsNullOrEmpty(s);
                if (p.Length > 1 && p[1] == '*'){
                    return IsMatch(s, p.Substring(2)) 
                        || (!string.IsNullOrEmpty(s) && (s[0] == p[0] || p[0] == '.') && IsMatch(s.Substring(1), p));
                } else {
                    return !string.IsNullOrEmpty(s) 
                        && (s[0] == p[0] || p[0] == '.') && IsMatch(s.Substring(1), p.Substring(1));
                }
            }

            public bool IsMatch1(string s, string p){
                if (string.IsNullOrEmpty(p)) return string.IsNullOrEmpty(s);
                bool[,] dp = new bool[s.Length + 1, p.Length + 1];
                dp[0,0] = true;
                // s could be "", p could be "a*"
                // so start i = 0
                for (int i = 0; i <= s.Length; i++){
                    for (int j = 1; j <= p.Length; j++){
                        if (j > 1 && p[j-1] == '*'){
                            dp[i,j] = dp[i, j-2] || (i > 0 && (s[i-1] == p[j-2] || p[j-2] == '.' ) && dp[i-1,j]);
                        }
                        else {
                            dp[i,j] = i > 0 && dp[i-1, j-1] && (s[i-1] == p[j-1] || p[j-1] == '.');
                        }
                        Console.WriteLine(s[i-1 < 0 ? i : i-1] +"," +p[j-1]);
                        Console.WriteLine(dp[i,j]);
                    }
                }
                return dp[s.Length, p.Length];
            }

            public bool IsMatch3(string s, string p){
                bool[] dp = new bool[p.Length + 1];        
                for (int i = 0; i <= s.Length; i++){
                    var pre = dp[0];
                    dp[0] = !(i > 0);
                    for (int j = 1; j <= p.Length; j++){
                        var tmp = dp[j];
                        if (j > 1 && p[j-1] == '*'){
                            dp[j] = dp[j-2] || (i > 0 && (s[i-1] == p[j-2] || p[j-2] == '.' ) && dp[j]);
                        }
                        else {
                            dp[j] = i > 0 && pre && (s[i-1] == p[j-1] || p[j-1] == '.');
                        }
                        pre = tmp;
                    }
                }
                return dp[p.Length];
            }
        }
    }
}

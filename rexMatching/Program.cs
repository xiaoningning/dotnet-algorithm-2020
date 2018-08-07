using System;

namespace rexMatching
{
    class Program
    {
        static void Main(string[] args)
        {
            var obj = new Solution();
            Console.WriteLine("regular expression match:{0}", obj.IsMatch("aab", "a.b*"));
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
        }
    }
}

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
        // '?' Matches any single character.
        // '*' Matches any sequence of characters (including the empty sequence).
        public class Solution {
            public bool IsMatch(string s, string p) {
                int si = 0, pi = 0, sstar = -1, pstar= -1;
                while (si < s.Length){
                    if (pi < p.Length && (p[pi] == '?' || s[si] == p[pi])){
                        si++;
                        pi++;
                    }
                    else if (pi < p.Length && p[pi] == '*'){
                        pstar = pi;
                        sstar = si;
                        pi++;
                    }
                    else if (pstar != -1){
                        pi = pstar + 1;
                        sstar++;
                        si = sstar;
                    }
                    else return false;

                }
                while (pi < p.Length && p[pi] == '*') pi++;
                return pi == p.Length;
            }
        }
    }
}

using System;
using System.Collections.Generic;

namespace romanToInt
{
    class Program
    {
        static void Main(string[] args)
        {
            var obj = new Solution();
            Console.WriteLine("roman to int : {0}", obj.RomanToInt("MCMXCIV"));
        }
    }
    public class Solution {
        public int RomanToInt(string s) {
            Dictionary<char, int> m = new Dictionary<char, int> {
                {'I', 1}, {'V', 5}, {'X', 10}, {'L', 50}, {'C', 100}, {'D', 500}, {'M', 1000}
            };
            int res = 0;
            for (int i = 0; i < s.Length; ++i) {
                int val = m[s[i]];
                if (i == s.Length - 1 || m[s[i+1]] <= m[s[i]]) res += val;
                else res -= val;
            }
            return res;
        }
    }
}

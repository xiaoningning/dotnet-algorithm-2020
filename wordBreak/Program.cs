using System;
using System.Collections.Generic;

namespace wordBreak
{
    class Program
    {
        static void Main(string[] args)
        {
            var obj = new Solution();
            List<string> dict = new List<string>(){"leet", "code"};
            Console.WriteLine("word break {0}", obj.WordBreak("leetcode", dict));
        }
    }
    public class Solution {
        public bool WordBreak(string s, IList<string> wordDict) {
            int n = s.Length;
            bool[] res = new bool[n+1];
            res[0] = true;
            for(int i = 1; i <=n; i++){
                for(int j = 0; j < i; j++){
                    if (res[j] && wordDict.Contains(s.Substring(j, i-j))) {
                        res[i] = true;
                        break;
                    }
                }            
            }
            return res[n];
        }
    }
}

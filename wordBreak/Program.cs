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
            var visited = new int[s.Length];
            Array.Fill(visited, -1);
            return helper(s, 0, wordDict, visited);
        }
        bool helper(string s, int start, IList<string> dict, int[] visited) {
            if (start >= s.Length) return true;
            if (visited[start] != -1) return visited[start] == 1;
            for (int i = start + 1; i <= s.Length; i++) {
                if (dict.Contains(s.Substring(start, i - start) )
                    && helper(s, i, dict, visited)) {
                        visited[start] = 1;
                        return true;
                    }
            }
            visited[start] = 0;
            return false;
        }
        public bool WordBreak1(string s, IList<string> wordDict) {
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

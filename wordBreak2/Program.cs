using System;
using System.Collections.Generic;

namespace wordBreak2
{
    class Program
    {
        static void Main(string[] args)
        {
            var obj = new Solution();
            List<string> dict = new List<string>(){"leet", "code"};
            var res = obj.WordBreak("leetcode", dict);
            Console.WriteLine("word break 2 {0}", string.Join(",", res));
        }
    }
    public class Solution {
        Dictionary<string, List<string>> m = new Dictionary<string, List<string>>();
        public IList<string> WordBreak(string s, IList<string> wordDict) {
            if (!s.Any()) return new List<string>(){""};
            if (m.ContainsKey(s)) return m[s];
            var res = new List<string>();
            foreach (string w in wordDict) {
                if (!s.StartsWith(w)) continue;
                var remains = WordBreak(s.Substring(w.Length), wordDict);
                foreach (var r in remains) 
                    res.Add(w + (r.Length == 0 ? "" : " ") + r);  
            }
            m[s] = res;
            return res;
        }
        public IList<string> WordBreak1(string s, IList<string> wordDict) {
            var map = new  Dictionary<string, List<string>>();
            return DFS(s, wordDict, map);
        }
        List<string> DFS(string s, IList<string> wordDict, Dictionary<string, List<string>> map){
            if(map.ContainsKey(s)) return map[s];
            if(string.IsNullOrEmpty(s)) return new List<string>(){""};
            List<string> res = new List<string>();
            foreach(string w in wordDict){
                if(s.StartsWith(w)){
                    string nextStr = s.Substring(w.Length);
                    List<string> remains = DFS(nextStr, wordDict, map);
                    foreach(string r in remains){
                        res.Add(w + (r.Length == 0 ? "" : " ") + r);
                    }
                }
            }
            map[s] = res;
            return res;
        }
    }
}

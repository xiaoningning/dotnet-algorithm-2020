using System;
using System.Collections.Generic;

namespace groupAnagrams
{
    class Program
    {
        static void Main(string[] args)
        {
            var obj = new Solution();
            string[] strs = new string[]{"eat", "tea", "tan", "ate", "nat", "bat"};
            Console.WriteLine("group anagrams:");
            var res  = obj.GroupAnagrams(strs);
            foreach (var r in res)
            {
                Console.WriteLine("{0},", string.Join(',', r));
            }
        }
    }
    public class Solution {
        public IList<IList<string>> GroupAnagrams(string[] strs) {
            List<IList<string>> res = new List<IList<string>>();
            Dictionary<string, List<string>> map = new Dictionary<string, List<string>>();
            foreach (string str in strs){
                int[] cnt = new int[26];
                string t = string.Empty;
                foreach (char c in str) cnt[c - 'a']++;
                foreach (int i in cnt) t += (char) i + "/"; 
                if (!map.ContainsKey(t)) map[t] = new List<string>();
                map[t].Add(str);
            }
            foreach(var pv in map){
                res.Add(pv.Value);
            }
            return res; 
        }
    }
}

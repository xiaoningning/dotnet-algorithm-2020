using System;
using System.Collections.Generic;

namespace palindromPairs
{
    class Program
    {
        static void Main(string[] args)
        {
            var obj = new Solution();
            string[] words = new string[]{"abcd", "dcba", "lls", "s", "sssll"};   
            var res =  obj.PalindromePairs(words);
            foreach(var r in res)  
                Console.WriteLine("Palindrome Pairs: {0}", string.Join(",", r));
        }
    }
    public class Solution {
        public IList<IList<int>> PalindromePairs(string[] words) {
            List<IList<int>> res = new List<IList<int>>();
            Dictionary<string, int> m = new Dictionary<string, int>();
            HashSet<int> s = new HashSet<int>();
            for (int i = 0; i < words.Length; i++){
                m[words[i]] = i;
                s.Add(i);
            }
            for (int i = 0; i < words.Length; i++){
                string t = words[i];
                int len = t.Length;
                char[] array = t.ToCharArray();
                Array.Reverse(array);
                t = new string(array);
                // bat, tab
                if (m.ContainsKey(t) && m[t] != i) res.Add(new List<int>(){i, m[t]});
                
                // abcd,cba or dcb, abcd
                foreach(var d in s) {
                    if (d != len && d < len && 
                        IsValid(t, 0, len - d -1) && m.ContainsKey(t.Substring(len - d)))
                        {
                            res.Add(new List<int>(){i, m[t.Substring(len - d)]});
                        }

                    if (d != len && d < len && 
                        IsValid(t, d, len - 1) && m.ContainsKey(t.Substring(0, d))) 
                         {
                            res.Add(new List<int>(){m[t.Substring(0, d)], i});
                         }
                }
            }
            return res;
        }
        private bool IsValid(string s, int left, int right) {
            while (left < right) {
                if (s[left++] != s[right--]) return false;
            }
            return true;
        }
    }
}

using System;

namespace minWindowSubstring
{
    class Program
    {
        static void Main(string[] args)
        {
            var obj = new Solution();
            string s = "ADOBECODEBANC";
            string t = "ABC";
            Console.WriteLine("min windows substr {0}", obj.MinWindow(s,t));
        }
    }
    public class Solution {
        public string MinWindow(string s, string t) {
            string res = "";
            int mn = Int32.MaxValue, left = 0, cnt = 0;
            var m = new int[128];
            foreach (char c in t) m[c]++;
            for (int i = 0; i < s.Length; i++){
                // do -- first, then compare
                if (--m[s[i]] >= 0) cnt++;
                while (cnt == t.Length){
                    if(i - left + 1 < mn){
                        mn = i - left + 1;
                        res = s.Substring(left, mn);
                    }
                    if (++m[s[left++]] > 0) cnt--; 
                }
            }
            return res;
        }
    }
}

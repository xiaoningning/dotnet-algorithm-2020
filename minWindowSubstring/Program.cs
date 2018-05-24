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
            int min = Int32.MaxValue;
            int cnt = t.Length;
            int begin = 0, end = 0, head = 0;
            int[] map = new int[128];
            foreach(char c in t) map[c-'A']++;
            while(end < s.Length){
                // compare first, then do --
                if(map[s[end++] -'A']-- > 0) cnt--;
                while(cnt == 0){
                    if(end - begin < min){
                        min = end - begin; 
                        head = begin;
                    }
                    // compare first, then do ++  
                    if(map[s[begin++] - 'A']++ == 0) cnt++; 
                }
            }
            return min == Int32.MaxValue ? "" : s.Substring(head, min);
        }
    }
}

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
            int min = Int32.MaxValue;
            int begin = 0, cnt = 0;
            int[] map = new int[128];
            foreach(char c in t) map[c]++;
            for(int i = 0; i < s.Length; i++){
                // do -- first, then compare
                if(--map[s[i]] >= 0) cnt++;
                while(cnt == t.Length){
                    if(i - begin + 1 < min){
                        min = i - begin + 1;
                        res = s.Substring(begin, min);
                    }
                    if (++map[s[begin]] > 0) cnt--; 
                    begin++;
                }
            }
            return res;
        }
    }
}

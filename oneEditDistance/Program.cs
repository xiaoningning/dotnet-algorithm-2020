using System;

namespace oneEditDistance
{
    class Program
    {
        static void Main(string[] args)
        {
            var obj = new Solution();
            Console.WriteLine("one edit distance {0}", obj.IsOneEditDistance("abc", "aec"));            
        }
    }
    public class Solution {
        public bool IsOneEditDistance(string s, string t) {
            for(int i = 0; i < Math.Min(s.Length, t.Length); i++){
                if(s[i] != t[i]){
                    if (s.Length == t.Length) return s.Substring(i + 1) == t.Substring(i + 1);
                    else if (s.Length < t.Length) return s.Substring(i) == t.Substring(i + 1);
                    else return s.Substring(i + 1) == t.Substring(i);
                }
            }
            // it must be 1 position different
            return Math.Abs(s.Length - t.Length) == 1;
        }
    }
}

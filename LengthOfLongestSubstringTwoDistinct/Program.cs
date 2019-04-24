using System;

namespace LengthOfLongestSubstringTwoDistinct
{
    class Program
    {
        static void Main(string[] args)
        {
            var obj = new Solution();
            Console.WriteLine("add binary {0}", obj.LengthOfLongestSubstringTwoDistinct("eceba"));
        }
    }
    
    public class Solution {
      public int LengthOfLongestSubstringTwoDistinct(string s) {
          int res = 0, left = 0;
          Dictionary<char, int> m = new Dictionary<char, int>();
          for (int i = 0; i < s.Length; ++i) {
              if (!m.ContainsKey(s[i])) m.Add(s[i], 0);
              ++m[s[i]];
              while (m.Count > 2) {
                  if (--m[s[left]] == 0) m.Remove(s[left]);
                  ++left;
              }
              res = Math.Max(res, i - left + 1);
          }
          return res;
      }
  }
}

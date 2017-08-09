using System;
using System.Collections.Generic;

namespace longestStringNoRepeat
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Input string: " + args[0]);
            int r = lengthOfLongestSubstring(args[0]);
            Console.WriteLine("result: " + r);
        }

        static int lengthOfLongestSubstring(string s){
            HashSet<char> map = new HashSet<char>();
            int result = 0;
            int i = 0, j = 0;
            while(i < s.Length){
                if(!map.Contains(s[i])){
                    map.Add(s[i]);
                    result = Math.Max(result, map.Count);
                    i++;
                }
                else{
                    map.Remove(s[j]);
                    j++;
                }
            }
            
            return map.Count;
        }
    }
}

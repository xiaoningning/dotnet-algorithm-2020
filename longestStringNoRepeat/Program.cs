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
            r = lengthOfLongestSubstring1(args[0]);
            Console.WriteLine("result1: " + r);
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
            
            return result;
        }

        static int lengthOfLongestSubstring1(string s){
            Dictionary<char, int> map = new Dictionary<char, int>();
            int result = 0;
            
            for (int i = 0, j = 0; i < s.Length; i++){
                if(map.ContainsKey(s[i]))
                {
                    j = Math.Max(map[s[i]], j);
                    map[s[i]] = i + 1;
                }else{
                    map.Add(s[i], i + 1);
                }
                result = Math.Max(result, i - j + 1);
            }
            
            return result;
        }
    }
}

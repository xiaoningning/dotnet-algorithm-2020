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

    public class Solution {
            public int LengthOfLongestSubstring(string s) {
                int res = 0;
                int left = -1; // init begin position
                int[] m = new int[128];
                // init pos for every char is -1
                // -1 means no repeat
                for (int i = 0; i < 128; i++) m[i] = -1;
                for (int i = 0; i < s.Length; i++) {
                    left = Math.Max(left, m[s[i]]);
                    m[s[i]] = i;
                    res = Math.Max(res, i - left);
                }
                return res;
            }

            public int LengthOfLongestSubstring1(string s) {
                HashSet<char> st = new HashSet<char>();
                int result = 0;
                int i = 0, j = 0;
                while(i < s.Length){
                    if(!st.Contains(s[i])){
                        st.Add(s[i]);
                        result = Math.Max(result, st.Count);
                        i++;
                    }
                    else{
                        st.Remove(s[j]);
                        j++;
                    }
                }
                return result;
            }
        }
}

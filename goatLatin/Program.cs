using System;
using System.Collections.Generic;

namespace goatLatin
{
    class Program
    {
        static void Main(string[] args)
        {
            var obj = new Solution();
            Console.WriteLine("Goat Latin:{0}", obj.ToGoatLatin("I speak Goat Latin"));            
        }
    }
    public class Solution {
        public static readonly HashSet<char> vowls = new HashSet<char>(){
            'a', 'e', 'i', 'o', 'u', 'A', 'E', 'I', 'O', 'U'
        };
        public string ToGoatLatin(string S) {
            string res = string.Empty;
            
            if (string.IsNullOrEmpty(S)) return res;
            
            int wordIdx = 1;
            foreach(string word in S.Split(' ')) {
                if (wordIdx != 1 ) res += " ";
                char firstChar = word[0];

                if (vowls.Contains(firstChar)) {
                    res += word;
                }
                else {
                    res += word.Substring(1);
                    res += firstChar;
                }
                res += "ma";
                for (int i = 1; i <= wordIdx; i++) {
                    res += "a";
                }
                wordIdx++;
            }
            return res;
        }
    }
}

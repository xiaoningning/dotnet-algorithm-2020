using System;
using System.Collections.Generic;

namespace letterPhoneCombinations
{
    class Program
    {
        static void Main(string[] args)
        {
            var obj = new Solution();
            Console.WriteLine("letter phone combination:");
            var res = obj.LetterCombinations("23");
            foreach(var r in res){
                Console.WriteLine("{0}", string.Join(',', r));
            } 
        }
    }
    public class Solution {
        static string[] dict = new string[]{"abc", "def", "ghi", "jkl", "mno", "pqrs", "tuv", "wxyz"};
        public IList<string> LetterCombinations(string digits) {
            List<string> res = new List<string>();
            if (digits.Length == 0) return res;
            LetterCombinationsDFS(digits, 0, new List<char>(), res);
            return res;
        }
        void LetterCombinationsDFS(string digits, int level, List<char> tmp, List<string> res){
            if (level == digits.Length) res.Add(new string(tmp.ToArray()));
            else {
                string str = dict[digits[level] - '2'];
                for (int i = 0; i < str.Length; ++i) {
                    tmp.Add(str[i]);
                    LetterCombinationsDFS(digits, level + 1, tmp, res);
                    tmp.RemoveAt(tmp.Count - 1);
                }
            }
        }
    }
}

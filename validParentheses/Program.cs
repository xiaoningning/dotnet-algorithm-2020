using System;
using System.Collections.Generic;

namespace validParentheses
{
    class Program
    {
        static void Main(string[] args)
        {
            var obj = new Solution();
            Console.WriteLine("valid parenthese :{0}", obj.IsValid("{[]}()"));
        }
    }
    public class Solution {
        public bool IsValid(string s) {
            Stack<char> parentheses = new Stack<char>();
            for (int i = 0; i < s.Length; ++i) {
                if (s[i] == '(' || s[i] == '[' || s[i] == '{') parentheses.Push(s[i]);
                else {
                    if (parentheses.Count == 0) return false;
                    if (s[i] == ')' && parentheses.Peek() != '(') return false;
                    if (s[i] == ']' && parentheses.Peek() != '[') return false;
                    if (s[i] == '}' && parentheses.Peek() != '{') return false;
                    parentheses.Pop();
                }
            }
            return parentheses.Count == 0;        
        }
    }
}

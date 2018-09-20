using System;

namespace isNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            var obj = new Solution();             
            Console.WriteLine("is number: {0}", obj.IsNumber("+1.34"));
            Console.WriteLine("is number: {0}", obj.IsNumber(" -1E.34"));
            Console.WriteLine("is number: {0}", obj.IsNumber("-1 34"));
            Console.WriteLine("is number: {0}", obj.IsNumber("abc."));
            Console.WriteLine("is number: {0}", obj.IsNumber(" -11.1e+3 "));
        }
    }
    public class Solution {
        public bool IsNumber(string s) {
            bool num = false, dot = false, exp = false, sign = false, numAfterE = true;
            int n = s.Length;
            for (int i = 0; i < n; ++i) {
                if (s[i] == ' ') {
                    if ((num || dot || sign || exp) &&
                        i < n-1 && s[i+1] != ' ') return false;
                }
                else if (s[i] >= '0' && s[i] <= '9') {
                    num = true;
                    numAfterE = true;
                }
                else if (s[i] == '.') {
                    if (dot || exp) return false;
                    dot = true;
                }
                else if (s[i] == '+' || s[i] == '-') {
                    if (i > 0 && !(s[i-1] == 'e' || s[i-1] == 'E') && s[i-1] != ' ') return false;
                    else sign = true;
                }
                else if (s[i] == 'e' || s[i] == 'E') {
                    if (exp || !num) return false;
                    exp = true;
                    numAfterE = false;
                }
                else return false;
            }

            return num && numAfterE;
        }
    }
}

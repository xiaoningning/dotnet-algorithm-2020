using System;

namespace isNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            var obj = new Solution(); 
            /*
            string s1 = "0"; // True
            string s2 = " 0.1 "; // True
            string s3 = "abc"; // False
            string s4 = "1 a"; // False
            string s5 = "2e10"; // True

            string s6 = "-e10"; // False
            string s7 = " 2e-9 "; // True
            string s8 = "+e1"; // False
            string s9 = "1+e"; // False
            string s10 = " "; // False

            string s11 = "e9"; // False
            string s12 = "4e+"; // False
            string s13 = " -."; // False
            string s14 = "+.8"; // True
            string s15 = " 005047e+6"; // True

            string s16 = ".e1"; // False
            string s17 = "3.e"; // False
            string s18 = "3.e1"; // True
            string s19 = "+1.e+5"; // True
            string s20 = " -54.53061"; // True

            string s21 = ". 1"; // False
            */
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

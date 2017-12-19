using System;

namespace validPalindrome2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Input string for palindrom: {0}", args[0]);
            Console.WriteLine("Result: {0}", isValidPalindrome(args[0]));
        }

        static bool isValidPalindrome(string s){
            int begin = 0, end = s.Length - 1;
            while(begin < end){
                if (s[begin] != s[end]) {
                    return isValid(s, begin + 1, end) || isValid(s, begin, end - 1);
                }
                else{
                    begin++;
                    end--;
                }                    
            }
            return true;
        }

        static bool isValid(string s, int begin, int end){
            while(begin < end){
                if (s[begin] != s[end]) return false;
                else {
                    begin++;
                    end--;
                }
            }
            return true;
        }
    }
}

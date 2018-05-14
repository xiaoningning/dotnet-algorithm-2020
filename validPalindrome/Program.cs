using System;

namespace validPalindrome
{
    class Program
    {
        static void Main(string[] args)
        {
            var obj = new Solution();
            string s = "A man, a plan, a canal: Panama";
            Console.WriteLine("Is Palindrome {0}", obj.IsPalindrome(s));
        }
    }
    public class Solution {
        public bool IsPalindrome(string s) {
            int left = 0, right = s.Length - 1;
            while(left <= right){
                if(!IsAlphaNum(s[left])) left++;
                else if(!IsAlphaNum(s[right])) right--;
                else if((s[left] - 'A') % 32 != (s[right] - 'A') % 32) return false;
                else {
                    left++;
                    right--;                
                }
            }
            return true;
        }
        bool IsAlphaNum(char ch) {
            if (ch >= 'a' && ch <= 'z') return true;
            if (ch >= 'A' && ch <= 'Z') return true;
            if (ch >= '0' && ch <= '9') return true;
            return false;
        }
    }
}

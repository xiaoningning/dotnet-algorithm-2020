using System;

namespace reverseWords2
{
    class Program
    {
        static void Main(string[] args)
        {
            var obj = new Solution();
            Console.WriteLine("reverse words: {0}", obj.ReverseWords(new char[]{'a','l',' ', 'b'}));
        }
    }
    
    public class Solution {
        public void ReverseWords(char[] str) {
            int left = 0, n = str.Length;
            for (int i = 0; i <= n; ++i) {
                if (i == n || str[i] == ' ') {
                    Reverse(str, left, i - 1);
                    left = i + 1;
                }
            }
            Reverse(str, 0, n - 1);
        }

        void Reverse(char[] str, int l, int r) {
            while (l < r) {
                var t = str[l];
                str[l] = str[r];
                str[r] = t;
                l++;
                r--;
            }

        }
    }
}

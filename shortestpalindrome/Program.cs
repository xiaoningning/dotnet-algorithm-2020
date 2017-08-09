using System;

namespace shortestpalindrome
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("find the shortest palindrome: " + args[0]);
            Console.WriteLine("the shortest palindrome: " + shortestPalindrome(args[0]));
            Console.WriteLine("find the shortest palindrome: " + args[0]);
            Console.WriteLine("the shortest palindrome: " + shortestPalindrome1(args[0]));
            Console.WriteLine("find the shortest palindrome (a clean O(n^2) algorithm): " + args[0]);
            Console.WriteLine("the shortest palindrome: " + shortestPalindrome2(args[0]));
        }

        static string shortestPalindrome(string s)
        {
            if (string.IsNullOrEmpty(s)) return null;

            int n = s.Length;
            char[] char_array = s.ToCharArray();
            Array.Reverse(char_array);
            string rev = new string(char_array);
            string s_new = s + "#" + rev;
            int n_new = s_new.Length;
            int[] next = new int[n_new];
            Console.WriteLine("new string: " + s_new);

            for (int i = 1; i < n_new; i++)
            {
                int t = next[i - 1];

                while (t > 0 && s_new[i] != s_new[t])
                {
                    t = next[t - 1];
                }

                if (s_new[i] == s_new[t])
                {
                    t++;
                }

                next[i] = t;
                Console.WriteLine("char: " + s_new[i] + " f: " + next[i]);
                Console.WriteLine("f: " + string.Join(",", next));
            }
            return rev.Substring(0, n - next[n_new - 1]) + s;
        }

        static string shortestPalindrome1(string s)
        {
            if (string.IsNullOrEmpty(s)) return null;

            int j = 0;
            for (int i = s.Length - 1; i >= 0; i--)
            {
                if (s.ToCharArray()[i] == s.ToCharArray()[j])
                {
                    j++;
                }
            }

            if (j == s.Length)
            {
                return s;
            }
            else
            {
                string suffix = s.Substring(j);
                char[] char_array = suffix.ToCharArray();
                Array.Reverse(char_array);
                string prefix = new string(char_array);
                Console.WriteLine("prefix: " + prefix);
                Console.WriteLine("subfix: " + suffix);
                string mid = shortestPalindrome1(s.Substring(0, j));
                Console.WriteLine("mid: " + mid);
                return prefix + mid + suffix;
            }
        }

        static string shortestPalindrome2(string s)
        {
            if (string.IsNullOrEmpty(s)) return null;

            int i = 0;
            int end = s.Length - 1;
            int j = end;
            char[] s_array = s.ToCharArray();

            while (i < j)
            {
                if (s_array[i] == s_array[j])
                {
                    i++;
                    j--;
                }
                else
                {
                    i = 0;
                    end--;
                    j = end;
                }
            }

            return ReverseStringDirect(s.Substring(end + 1)) + s;
        }

        static string ReverseStringDirect(string s)
        {
            char[] array = new char[s.Length];
            int forward = 0;
            for (int i = s.Length - 1; i >= 0; i--)
            {
                array[forward++] = s[i];
            }
            return new string(array);
        }
    }
}

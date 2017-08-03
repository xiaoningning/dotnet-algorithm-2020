using System;

namespace shortestpalindrome
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("find the shortest palindrome: " + args[0]);
            Console.WriteLine("the shortest palindrome: " + shortestpalindrome(args[0]));
            Console.WriteLine("find the shortest palindrome: " + args[0]);
            Console.WriteLine("the shortest palindrome: " + shortestpalindrome1(args[0]));
        }

        static string shortestpalindrome(string s){
            int n = s.Length;
            char[] char_array = s.ToCharArray();
            Array.Reverse(char_array);
            string rev = new string(char_array);
            string s_new = rev + "#" + s;
            int n_new = s_new.Length;
            int[] f = new int[n_new];
            Console.WriteLine("new string: " + s_new);

            for (int i = 1; i < n_new; i++) {
                int t = f[i - 1];
            
                while (t > 0 && s_new[i] != s_new[t]){
                    t = f[t - 1];
                }                
            
                if (s_new[i] == s_new[t]){
                    t++;
                }                
            
                f[i] = t;
                Console.WriteLine("char: " + s_new[i] + " f: " + f[i]);
                Console.WriteLine("f: " + string.Join(",", f));
            }
            return rev.Substring(0, n - f[n_new - 1]) + s;
        }

        static string shortestpalindrome1(string s){
            int j = 0;
            for (int i = s.Length - 1; i >= 0; i--){
                if (s.ToCharArray()[i] == s.ToCharArray()[j]){
                    j++;
                }
            }

            if (j == s.Length){
                return s;
            }
            else {
                string suffix = s.Substring(j);
                char[] char_array = suffix.ToCharArray();
                Array.Reverse(char_array);
                string prefix = new string(char_array);
                Console.WriteLine("prefix: " + prefix);
                Console.WriteLine("subfix: " + suffix);
                string mid = shortestpalindrome1(s.Substring(0, j));
                Console.WriteLine("mid: " + mid);
                return prefix + mid + suffix;
            }    
        }
    }
}

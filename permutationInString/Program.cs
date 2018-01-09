using System;

namespace permutationInString
{
    class Program
    {
        static void Main(string[] args)
        {
            string p = args[0];
            string s = args[1];
            Console.WriteLine("input pattern: " + p);
            Console.WriteLine("search string: " + s);
            Console.WriteLine("find pattern: " + PermutationInString(p, s));
        }

        static bool PermutationInString(string p, string s)
        {
            int[] map = new int[256];
            int count = p.Length;
            for (int i = 0; i < p.Length; i++)
            {
                map[p[i]]++;
            }

            int j = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (map[s[i]]-- > 0) count--;
                while (count == 0)
                {
                    if (i - j + 1 == p.Length) return true;
                    if (++map[s[j++]] > 0) count++;
                }
            }
            return false;
        }
    }
}

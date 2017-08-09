using System;

namespace kmpSearch
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("source: " + args[0]);
            Console.WriteLine("pattern: " + args[1]);
            int findIndex = kmpSearch1(args[0], args[1]);
            Console.WriteLine("find the pattern at " + findIndex);
            findIndex = kmpSearch2(args[0], args[1]);
            Console.WriteLine("find the pattern at " + findIndex);
        }

        static int kmpSearch1(string s, string p)
        {

            if (string.IsNullOrEmpty(s) || string.IsNullOrEmpty(p)) return -1;
            if (s.Length < p.Length) return -1;

            int i = 0;
            int j = 0;
            char[] s_char = s.ToCharArray();
            char[] p_char = p.ToCharArray();
            int[] next = buildNextTable1(p_char);
            Console.WriteLine("next: " + string.Join(",", next));

            while (i < s.Length && j < p.Length)
            {
                if (j == -1 || s_char[i] == p_char[j])
                {
                    i++;
                    j++;

                    if (j == p.Length) return i - j;
                }
                else
                {
                    j = next[j];                   
                }
            }

            return -1;
        }

        static int kmpSearch2(string s, string p)
        {

            if (string.IsNullOrEmpty(s) || string.IsNullOrEmpty(p)) return -1;
            if (s.Length < p.Length) return -1;

            int i = 0;
            int j = 0;
            char[] s_char = s.ToCharArray();
            char[] p_char = p.ToCharArray();
            int[] next = buildNextTable2(p_char);
            Console.WriteLine("next: " + string.Join(",", next));

            while (i < s.Length && j < p.Length)
            {                
                if (s_char[i] == p_char[j])
                {
                    i++;
                    j++;

                    if (j == p.Length) return i - j;
                }
                else
                {                    
                    if (j != 0) j = next[j - 1];
                    else i++;
                }
            }

            return -1;
        }

        // NextTable: next position
        static int[] buildNextTable1(char[] p_char)
        {
            int[] next = new int[p_char.Length];
            next[0] = -1;
            int j = 0;
            int k = -1;

            while (j < p_char.Length - 1)
            {
                if (k == -1 || p_char[j] == p_char[k])
                {
                    j++;
                    k++;
                    next[j] = k;
                }
                else
                {
                    k = next[k];
                }
            }
            return next;
        }

        // The length of the longest proper prefix which is also suffix for each position
        static int[] buildNextTable2(char[] p_char)
        {
            int[] next = new int[p_char.Length];
            int k = 0; // the length of prefix and suffix
            int j = 1;

            while (j < p_char.Length)
            {
                if (p_char[j] == p_char[k])
                {
                    k++;
                    next[j] = k;
                    j++;
                }
                else
                {
                    if (k != 0)
                    {
                        k = next[k - 1];
                    }
                    else
                    {
                        next[j] = 0;
                        j++;
                    }
                }
            }
            return next;
        }
    }
}

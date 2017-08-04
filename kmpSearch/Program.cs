using System;

namespace kmpSearch
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("source: " + args[0]);
            Console.WriteLine("pattern: " + args[1]);
            int findIndex = kmpSearch(args[0], args[1]);
            Console.WriteLine("find the pattern at " + findIndex);
        }

        static int kmpSearch(string s, string p){
            
            if (string.IsNullOrEmpty(s) || string.IsNullOrEmpty(p)) return -1;
            
            int i = 0;
            int j = 0;
            char[] s_char = s.ToCharArray();
            char[] p_char = p.ToCharArray();
            int[] next = buildNextTable1(p_char);
            
            while(i < s.Length && j < p.Length){
                if (j == -1 || s_char[i] == p_char[j]){
                    i++;
                    j++;
                }
                else {
                    j = next[j];
                }                
            }

            return ( j == p.Length) ? i-j : -1;
        }

        static int[] buildNextTable(char[] p_char){
            int[] next = new int[p_char.Length];
            next[0] = -1;
            int j = 0;
            int k = -1;

            while(j < p_char.Length - 1){
                if(k == -1 || p_char[j] == p_char[k]){
                    j++;
                    k++;
                    next[j] = (p_char[j] != p_char[k]) ? k : next[k];                    
                }
                else{
                    k = next[k];
                }
            }
            return next;
        }

        static int[] buildNextTable1(char[] p_char){
            int[] next = new int[p_char.Length];
            next[0] = -1;
            int j = 0;
            int k = -1;

            while(j < p_char.Length - 1){
                if(k == -1 || p_char[j] == p_char[k]){
                    j++;
                    k++;
                    next[j] = k;                    
                }
                else{
                    k = next[k];
                }
            }
            return next;
        }
    }
}

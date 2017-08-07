using System;

namespace strStr
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("source: " + args[0]);
            Console.WriteLine("target: " + args[1]);
            int i = strStrBruteForce(args[0], args[1]);
            Console.WriteLine("find target at index by Brute Force:" + i);
            i = strStrRabinKarp(args[0], args[1]);
            Console.WriteLine("find target at index by Rabin Karp:" + i);
        }

        static int strStrBruteForce(string s, string t)
        {
            if (string.IsNullOrEmpty(s) ||
            string.IsNullOrEmpty(t) ||
            s.Length < t.Length)
            {
                return -1;
            }

            for (int i = 0; i <= s.Length - t.Length; i++)
            {
                int j = 0;
                for (j = 0; j < t.Length; j++)
                {
                    if (s[i + j] != t[j])
                    {
                        break;
                    }
                }

                if (j == t.Length)
                {
                    return i;
                }
            }
            return -1;
        }

        static readonly int FACTOR = 256; // the number of characters in input ASCII 
        static readonly int MOD = 97; // a prime number

        static int strStrRabinKarp(string s, string t)
        {
            if (string.IsNullOrEmpty(s) ||
            string.IsNullOrEmpty(t))
            {
                return -1;
            }
            
            int M = t.Length;
            
            if (s.Length < M) return -1;
            int t_hash = computeHash(t, M);
            int s_hash = computeHash(s, M);

            int RM = 1;
            // pre-compute R^(M-1) % MOD = POW(FACTOR, M-1) % MOD
            for (int i = 1; i <= M - 1; i++)
            {
                RM = (RM * FACTOR) % MOD;
            }

            for (int i = 0; i <= s.Length - M; i++)
            {
                if (s_hash == t_hash &&
                strEqual(s.Substring(i, M), t))
                {
                    return i; // return the found index
                }
                
                if (i < s.Length - M){
                // Update the hash value
                s_hash = ((s_hash - RM * s[i]) * FACTOR + s[i + M]) % MOD;
                if (s_hash < 0) s_hash += MOD;
                }
            }
            return -1;
        }

        static int computeHash(string s, int len)
        {
            int hash = 0;
            for (int i = 0; i <= len - 1; i++)
            {
                hash = (hash * FACTOR + s[i]) % MOD;
            }
            // we do not use long, it might be < 0;
            return (hash < 0) ? hash + MOD : hash;
        }

        static bool strEqual(string s, string t)
        {
            if (string.IsNullOrEmpty(s) && string.IsNullOrEmpty(t)) return true;
            if (string.IsNullOrEmpty(s) || string.IsNullOrEmpty(t)) return false;
            if (s.Length != t.Length) return false;

            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] != t[i]) return false;
            }

            return true;
        }
    }
}

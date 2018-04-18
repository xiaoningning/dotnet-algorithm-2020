using System;
using System.Collections.Generic;

namespace letterCasePermutation
{
    class Program
    {
        static void Main(string[] args)
        {
            string S = args[0];
            Console.WriteLine("string: " + args[0]);
            Console.WriteLine("Letter Case permutation: {0}", string.Join(',', LetterCasePermutation(S)));
        }

        static IList<string> LetterCasePermutation(string S) {
            List<string> res = new List<string>();
            res.Add(S);
            int n = S.Length;
            for (int i = 0; i < n; i++){
                if (S[i] >= '0' && S[i] <= '9') continue;
                List<string> temp = new List<string>();
                foreach(string s in res){
                    char[] c = s.ToCharArray();
                    c[i] = char.ToLower(c[i]);
                    temp.Add(new string(c));
                    c[i] = char.ToUpper(c[i]);
                    temp.Add(new string(c));
                }
                res = temp;
            }        
            return res;
        }
    }
}

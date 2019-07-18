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
            var o = new Solution();
            Console.WriteLine("Letter Case permutation: {0}", string.Join(',', o.LetterCasePermutation(S)));
        }

        public class Solution {
            public IList<string> LetterCasePermutation1(string S) {
                List<string> res = new List<string>();
                if (S == null) return res;
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

            public IList<string> LetterCasePermutation(string S) {
                List<string> res = new List<string>();
                if (S == null) return res;
                Helper(S.ToArray(), res, 0);
                return res;
            }
            void Helper(char[] s, List<string> res, int p) {
                if (p == s.Length) {
                    res.Add(new string(s));
                    return;
                }
                if (s[p] >= '0' && s[p] <= '9') {
                    Helper(s, res, p + 1);
                    return;
                }
                s[p] = char.ToLower(s[p]);
                Helper(s, res, p + 1);
                s[p] = char.ToUpper(s[p]);
                Helper(s, res, p + 1);
            }
        }
    }
}

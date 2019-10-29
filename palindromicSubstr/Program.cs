using System;
using System.Collections.Generic;
using System.Text;

namespace palindromicSubstr
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Input string: {0}", args[0]);
            Console.WriteLine("Reselt count: {0}", CountSubstrings(args[0]));
        }

        static int CountSubstrings(string s) {
            int res = 0;
            if (!string.IsNullOrEmpty(s)){
                List<string> resList = new List<string>();
                for (int i = 0; i < s.Length; i++){
                    Helper(s, i, i, resList);
                    Helper(s, i, i+1, resList);
                }
                Console.WriteLine("output: {0}", string.Join(",", resList));
                res = resList.Count;
            }
            return res;
        }

        static void Helper(string s, int left, int right, List<string> resList){
            List<char> sb = new List<char>();                
            while(left >=0 && right < s.Length && s[left] == s[right]){
                sb.Insert(0, s[left]);
                if (left != right) sb.Add(s[right]);
                resList.Add(new string(sb.ToArray()));                    
                left--; right++;
            }
        }

        int CountSubstrings2(string s) {
            int res = 0;
            if (!string.IsNullOrEmpty(s)){
                for (int i = 0; i < s.Length; i++){
                    res += Helper(s, i, i);
                    res += Helper(s, i, i+1);
                }                
            }
            return res;
        }

         int Helper2(string s, int left, int right){
            int res = 0;
             while(left >=0 && right < s.Length && s[left] == s[right]){
                left--; right++; res++;
            }
             return res;
        }
}
    }

    public class Solution {
        public int CountSubstrings(string s) {
            int res = 0;
            int n = s.Length;
            bool[,] dp = new bool[n,n];
            for (int i = n - 1; i >= 0; --i) {
                for (int j = i; j < n; ++j) {
                    dp[i,j] = (s[i] == s[j]) && (j - i <= 2 || dp[i + 1,j - 1]);
                    if (dp[i,j]) ++res;
                }
            }
            return res;
        }

        public int CountSubstrings1(string s) {
            int res = 0;
            if (!string.IsNullOrEmpty(s)){
                for (int i = 0; i < s.Length; i++){
                    res += Helper(s, i, i);
                    res += Helper(s, i, i+1);
                }                
            }
            return res;
        }

         int Helper(string s, int left, int right){
            int res = 0;
             while(left >=0 && right < s.Length && s[left] == s[right]){
                left--; right++; res++;
            }
             return res;
        }
    }
}

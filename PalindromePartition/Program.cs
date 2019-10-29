using System;
using System.Collections.Generic;

namespace PalindromePartition
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = "aab";
            var res = Partition(s);
            foreach(var r in res){
                Console.WriteLine("result list: {0}", string.Join(',', r));
            }
        }
        static IList<IList<string>> Partition(string s) {
            List<IList<string>> res = new List<IList<string>>();
            BackTrack(s, 0, new List<string>(), res);        
            return res;
        }
        static void BackTrack(string s, int start, List<string> temp, List<IList<string>> res){
            if (start == s.Length) res.Add(new List<string>(temp));
            else {
                for(int i = start; i < s.Length; i++){
                    if(IsPalindrome(s, start, i)){
                        temp.Add(s.Substring(start, i - start + 1));
                        BackTrack(s, i + 1, temp, res);
                        temp.RemoveAt(temp.Count -1);
                    }                    
                }            
            }
        }
        static bool IsPalindrome(string s, int low, int high){
            while(low < high)
                if(s[low++] != s[high--]) return false;
            return true;
        } 
    }
    
    public class Solution {
        public IList<IList<string>> Partition(string s) {
            List<IList<string>> res = new List<IList<string>>();
            BackTrack(s, 0, new List<string>(), res);        
            return res;        
        }
        void BackTrack(string s, int start, List<string> temp, List<IList<string>> res){
            if (start == s.Length) res.Add(new List<string>(temp));
            else {
                for(int i = start; i < s.Length; i++){
                    if(IsPalindrome(s, start, i)){
                        temp.Add(s.Substring(start, i - start + 1));
                        BackTrack(s, i + 1, temp, res);
                        temp.RemoveAt(temp.Count -1);
                    }                    
                }            
            }
        }
        public bool IsPalindrome(string s, int low, int high){
            while(low < high)
                if(s[low++] != s[high--]) return false;
            return true;
        } 
        // output is not right
        public IList<IList<string>> Partition2(string s){
            int n = s.Length;
            var res = new List<IList<string>>[n+1];
            for(int i = 0; i < n+1; i++) 
                res[i]= new List<IList<string>>(){new List<string>(){}};
            bool[,] dp = new bool[n,n];
            for (int i = 0; i < n; i++) {
                for (int j = 0; j <= i; j++) {
                    if (s[j] == s[i] && (i - j <= 2 || dp[j + 1,i - 1])) {
                        dp[j,i] = true;
                        string cur = s.Substring(j, i-j+1);
                        for(int m = 0; m < res[j].Count; m++) {
                            res[j][m].Add(cur);
                            res[j+1].Add(new List<string>(res[j][m]));
                            // Console.WriteLine(string.Join(",",res[j][m]));
                        }
                    }  
                }
            }
            return res[n];
        }
    }
}

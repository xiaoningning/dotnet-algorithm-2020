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
}

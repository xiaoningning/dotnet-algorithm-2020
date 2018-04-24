using System;
using System.Collections.Generic;

namespace CombinationSum3
{
    class Program
    {
        static void Main(string[] args)
        {
            int k = 3, n = 9;
            var res = CombinationSum3(k, n);
            foreach(var r in res){
                Console.WriteLine("result list: {0}", string.Join(',', r));
            } 
        }
        static IList<IList<int>> CombinationSum3(int k, int n) {
            List<IList<int>> res = new List<IList<int>>();
            BackTrack(k, n, 1, new List<int>(), res);        
            return res;
        }
        static void BackTrack(int k, int remain, int start, List<int> temp, List<IList<int>> res){
            if (remain < 0) return;
            else if (remain == 0 && temp.Count == k) res.Add(new List<int>(temp));
            else {
                for(int i = start; i <= 9; i++){
                    temp.Add(i);                    
                    BackTrack(k, remain - i, i + 1, temp, res);
                    temp.RemoveAt(temp.Count -1);
                }            
            }
        }
    }
}

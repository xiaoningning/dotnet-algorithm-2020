using System;
using System.Collections.Generic;

namespace expressionAddOp
{
    class Program
    {
        static void Main(string[] args)
        {
            string num = "105";
            int t = 5;
            var obj = new Solution();
            var res = obj.AddOperators(num, t);
            foreach(var r in res){
                Console.WriteLine(r);
            }
        }
    }
    public class Solution {
        public IList<string> AddOperators(string num, int target) {
            var res = new List<string>();
            if (string.IsNullOrEmpty(num)) return res;
            BackTrack(num, target, string.Empty, res, 0, 0); 
            return res;
        }
        void BackTrack(string num, 
                       int target, 
                       string path, 
                       List<string> res, 
                       Int64 eval, 
                       Int64 diff){
            if(0 == num.Length && target == eval) {
                res.Add(path);
                return;
            }

            for(int len = 1; len <= num.Length; len++){
                string s = num.Substring(0, len);
                if(s.Length > 1 && s[0] == '0') return;                    
                Int64 cur = Int64.Parse(s);
                string next = num.Substring(len);
                if(string.IsNullOrEmpty(path)){
                    BackTrack(next, target, path + s, res, eval+cur, cur);
                }
                else{
                    BackTrack(next, target, path + "+" + cur, res, eval + cur, cur);
                    BackTrack(next, target, path + "-" + cur, res, eval - cur, -cur);
                    // 1+2 -> 1+2*3 => 1-2 + 2*3
                    BackTrack(next, target, path + "*" + cur, res, eval - diff + diff * cur, diff * cur );
                }
            }
        }
    }
}

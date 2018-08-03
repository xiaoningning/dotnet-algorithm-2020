using System;

namespace countAndSay
{
    class Program
    {
        static void Main(string[] args)
        {
            var obj = new Solution();
            Console.WriteLine("count and say: {0}", obj.CountAndSay(2));
        }
    }
    public class Solution {
        public string CountAndSay(int n) {
            if (n <= 0) return "";
            string res = "1";
            while (--n > 0) {
                string t = string.Empty;
                for (int i = 0; i < res.Length; ++i) {
                    int cnt = 1;
                    while (i + 1 < res.Length && res[i] == res[i + 1]) {
                        ++cnt;
                        ++i;
                    }
                    t += cnt.ToString() + res[i];
                }
                res = t;
            }
            return res;            
        }
    }
}

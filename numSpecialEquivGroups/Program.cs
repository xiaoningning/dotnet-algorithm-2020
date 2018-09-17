using System;
using System.Collections.Generic;

namespace numSpecialEquivGroups
{
    class Program
    {
        static void Main(string[] args)
        {
            var obj = new Solution();
            string[] A = new string[]{"a","b","c","a","c","c"};
            Console.WriteLine("Num Special Equiv Groups:{0}", obj.NumSpecialEquivGroups(A));
        }
    }
    public class Solution {
        public int NumSpecialEquivGroups(string[] A) {
            HashSet<string> res = new HashSet<string>();            
            foreach(string s in A) {
                int[] odd = new int[256];
                int[] even = new int[256];
                
                // array is to sort s.
                for(int i = 0; i < s.Length; i++){
                    if (i % 2 == 0) even[s[i]]++;
                    else odd[s[i]]++;
                }
                
                string oddStr = string.Empty;
                string evenStr = string.Empty;
                
                // index is char for s.
                for(int i = 0; i < even.Length; i++) {
                    while(even[i]-- != 0) evenStr += (char)i;
                }
                for(int i = 0; i < odd.Length; i++) {
                    while(odd[i]-- != 0) oddStr += (char)i;
                }
                res.Add(oddStr + evenStr);
            }
            return res.Count;
        }
    }
}

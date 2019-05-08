using System;

namespace hIndex
{
    class Program
    {
        static void Main(string[] args)
        {
            var obj = new Solution();
            int[] citations = new int[]{3,0,6,1,5};
            Console.WriteLine("H index of citiations: {0}", obj.HIndex(citations));   
        }
    }
    public class Solution {
        // A scientist has index h 
        // if h of his/her N papers have 
        // at least h citations each, 
        // and the other N − h papers have no more than h citations each.
        public int HIndex(int[] citations) {
            int n = citations.Length;
            int[] map = new int[n+1];
            foreach(int c in citations){
                if(c >= n) map[n]++;
                else map[c]++;
            }
            int count = 0;
            for(int i = n; i >= 0; i--) {
                count += map[i];
                if(count >= i) {
                    return i;
                }
            }
            return 0;
        }
    }
}

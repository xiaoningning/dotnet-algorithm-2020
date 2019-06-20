using System;

namespace hIndex2
{
    class Program
    {
        static void Main(string[] args)
        {
            var obj = new Solution();
            int[] citations = new int[]{6,5,1,3,0};
            Console.WriteLine("H index of citiations: {0}", obj.HIndex(citations));   
        }
    }
    public class Solution {
        public int HIndex(int[] citations) {
            int len = citations.Length;
            int left = 0;
            int right = len;
            while(left < right){
                int mid = left + (right -left)/2;
                if(citations[mid] == (len-mid)) return citations[mid];
                else if(citations[mid] > len - mid) right = mid;
                else left = mid + 1;
            }
            return len - left;
        }
    }
}

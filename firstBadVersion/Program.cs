using System;

namespace firstBadVersion
{
    class Program
    {
        static void Main(string[] args)
        {
            var obj = new Solution();
            Console.WriteLine("First Bad Version in 5: {0}", obj.FirstBadVersion(5));                  
        }
    }
    public class Solution {
        public int FirstBadVersion(int n) {
            int left = 1, right = n;
            while(left < right) {
                int mid = left + (right-left) /2;
                if(IsBadVersion(mid)) right = mid;
                else left =  mid + 1;
            }
            return left;
        }
        bool IsBadVersion(int version){
           if (version == 3)  return true;
           else return false;
        }
    }
}

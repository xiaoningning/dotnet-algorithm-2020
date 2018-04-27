using System;

namespace findCelebrity
{
    class Program
    {
        static void Main(string[] args)
        {
            var obj = new Solution();
            Console.WriteLine("Find Celebrity in 5: {0}", obj.FindCelebrity(5));
            Console.WriteLine("Find Celebrity in 2: {0}", obj.FindCelebrity(2));            
        }
    }
    public class Solution {
        public int FindCelebrity(int n) {
            int res = 0;
            for (int i = 0; i < n; ++i) {
                if (Knows(res, i)) res = i;
            }
            for (int i = 0; i < n; ++i) {
                if (res != i && (Knows(res, i) || !Knows(i, res))) return -1;
            }
            return res; 
        }
        bool Knows(int a, int b){
            if (b == 3 && a != b) return true;
            else return false;
        }
    }
}

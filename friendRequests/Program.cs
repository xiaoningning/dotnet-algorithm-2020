using System;

namespace friendRequests
{
    class Program
    {
        static void Main(string[] args)
        {
            var obj = new Solution();
            int[] ages = new int[]{16,17,18};
            Console.WriteLine("Friend Requests: {0}", obj.NumFriendRequests(ages));
        }
    }
    public class Solution {
        public int NumFriendRequests(int[] ages) {
            int res = 0;
            int[] numInAge = new int[121];
            int[] sumInAge = new int[121];
            foreach (int age in ages) numInAge[age]++;
            for (int i = 1; i <= 120; i++) sumInAge[i] = numInAge[i] + sumInAge[i - 1];
            
            // to be friend, B must be in (A * 0.5 + 7, A]
            // A at least >= 15
            for (int a = 15; a <= 120; a++) {
                if (numInAge[a] == 0) continue;
                int cnt = sumInAge[a] - sumInAge[a/2 + 7];
                // a can not friend with a themselves, - numInAge[a]
                res += cnt * numInAge[a] - numInAge[a]; 
            }
            return res;
        }
    }
}

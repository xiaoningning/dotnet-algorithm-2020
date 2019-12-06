public class Solution {
    public int LeastOpsExpressTarget(int x, int target) {
        // x = 3, target = 2. 
        // 2 = 3/3 + 3/3 (two +3/3) or 2 = 3 - 3/3 (one -3/3)
        if (x > target) return Math.Min(target * 2 - 1, (x - target) * 2);
        else if (x == target) return 0;
        int k = 0; long sum = x;
        while (target - sum > 0) {sum *= x; k++;}
        if (target == sum) return k;
        // x*x*..x + (rest)
        int pos = Int32.MaxValue;
        // x*x*..x*x - (rest)
        int neg = Int32.MaxValue;
        if (sum - target < target) neg = LeastOpsExpressTarget(x, (int)(sum - target)) + k; 
        //  remove extra k++
        pos = LeastOpsExpressTarget(x, (int)(target - sum/x)) + k - 1;
        // extra + or -
        return Math.Min(pos, neg) + 1;
    }
    
    public int LeastOpsExpressTarget1(int x, int target) {
        // x > 0, 1 = x/x
        // positive the number of operations needed to get y % (x ^ (k+1))
        // negative the number of operations needed to get x ^ (k + 1) - y % (x ^ (k))
        // x = 3, target = 2. 
        // 2 = 3/3 + 3/3 or 2 = 3 - 3/3
        // k is # of times
        int pos = 0, neg = 0, k = 0, pos2, neg2, cur;
        while (target > 0) {
            cur = target % x;
            // times => fastest way to reach target
            target /= x;
            if (k > 0) {
                pos2 = Math.Min(cur * k + pos, (cur + 1) * k + neg);
                neg2 = Math.Min((x - cur) * k + pos, (x - cur - 1) * k + neg);
                pos = pos2;
                neg = neg2;
            } else {
                // +x/x or -x/x => +/- and / => 2 operators
                pos = cur * 2; 
                neg = (x - cur) * 2;
            }
            k++;
        }
        // each pos/neg is 2 operators
        // at the end, remove 1 extra +/1
        return Math.Min(pos, k + neg) - 1;
    }
}

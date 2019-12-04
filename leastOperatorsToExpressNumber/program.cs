public class Solution {
    public int LeastOpsExpressTarget(int x, int target) {
        // x > 0, 1 = x/x
        // positive the number of operations needed to get y % (x ^ (k+1))
        // negative the number of operations needed to get x ^ (k + 1) - y % (x ^ (k + 1))
        // x = 3, target = 2. 
        // 2 = 3/3 + 3/3 or 2 = 3 - 3/3
        int pos = 0, neg = 0, k = 0, pos2, neg2, cur;
        while (target > 0) {
            cur = target % x;
            target /= x;
            if (k > 0) {
                pos2 = Math.Min(cur * k + pos, (cur + 1) * k + neg);
                neg2 = Math.Min((x - cur) * k + pos, (x - cur - 1) * k + neg);
                pos = pos2;
                neg = neg2;
            } else {
                pos = cur * 2; // x/x => *2
                neg = (x - cur) * 2;
            }
            k++;
        }
        return Math.Min(pos, k + neg) - 1;
    }
}

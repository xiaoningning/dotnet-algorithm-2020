public class Solution {
    public int Reverse(int x) {
        int res = 0;
        while (x != 0) {
            // check if reverse overflow int range
            // use long, after reverse and check overflow
            if (Math.Abs(res) > Int32.MaxValue / 10) return 0;
            res = res * 10 + x % 10;
            x /= 10;
        }
        return res;
    }
}

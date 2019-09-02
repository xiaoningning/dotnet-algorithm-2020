public class Solution {
    public int MinMoves(int[] nums) {
        int res = 0, min = Int32.MaxValue;
        foreach (var n in nums) min = Math.Min(min, n);
        foreach (var n in nums) res += n - min;
        return res;
    }
}

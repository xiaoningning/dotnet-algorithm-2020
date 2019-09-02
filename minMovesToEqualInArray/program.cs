public class Solution {
    public int MinMoves(int[] nums) {
        int res = 0, min = Int32.MaxValue;
        // a move is incrementing n - 1 elements by 1
        // = a move is decreasing max value element by 1
        // use max could overflow
        foreach (var n in nums) min = Math.Min(min, n);
        foreach (var n in nums) res += n - min;
        return res;
    }
}

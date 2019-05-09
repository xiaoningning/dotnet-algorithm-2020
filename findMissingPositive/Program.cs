public class Solution {
    public int FirstMissingPositive(int[] nums) {
        HashSet<int> s = new HashSet<int>();
        int max = 0;
        foreach (int n in nums) {
            if (n > 0) {
                s.Add(n);
                max = Math.Max(max, n);
            }
        }
        for (int i = 1; i <= max; i++){
            if (!s.Contains(i)) return i;
        }
        return max + 1;
    }
}

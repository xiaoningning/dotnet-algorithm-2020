public class Solution {
    public int FindMaximumXOR(int[] nums) {
        int maxXor = 0, mask = 0;
        for (int i = 31; i >= 0; i--) {
            mask |= 1 << i;
            var s = new HashSet<int>();
            foreach (int n in nums) s.Add(n & mask);
            int tmp = maxXor | (1 << i);
            foreach (var prefix in s) {
                // x ^ y = tmp => x ^ tmp = y
                if (s.Contains(tmp ^ prefix)) {
                    maxXor = tmp;
                    Console.WriteLine(Convert.ToString(maxXor, 2));
                    break;
                }
            }
        }
        return maxXor;
    }
}

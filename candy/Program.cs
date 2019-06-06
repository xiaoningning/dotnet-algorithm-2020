public class Solution {
    public int Candy(int[] ratings) {
        int n = ratings.Length;
        int[] res = new int[n];
        for (int i = 0; i < n; i++) res[i] = 1;
        for (int i = 0; i < n - 1; i++) {
            if (ratings[i+1] > ratings[i]) res[i+1] = res[i] + 1;
        }
        for (int i = n - 1; i > 0; i--) {
            if (ratings[i-1] > ratings[i]) res[i-1] = Math.Max(res[i-1], res[i] + 1);
        }
        return res.Sum();
    }
}

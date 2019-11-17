public class Solution {
    public int[] DistributeCandies(int candies, int num_people) {
        int[] res = new int[num_people];
        for (int give = 0; candies >= 0; candies -= give) {
            res[give % num_people] += Math.Min(candies, ++give);
        }
        return res;
    }
}

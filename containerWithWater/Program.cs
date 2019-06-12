public class Solution {
    public int MaxArea(int[] height) {
        int i = 0, j = height.Length - 1, res = 0;
        while (i < j) {
            var minH = Math.Min(height[i], height[j]);
            res = Math.Max(res, minH * (j -i));
            while (i < j & minH == height[i]) i++;
            while (i < j & minH == height[j]) j--;
        }
        return res;
    }
}

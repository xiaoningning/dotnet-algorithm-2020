public class Solution {
    public int FindMinArrowShots(int[][] points) {
        if (!points.Any()) return 0;
        // non-overlapping interval
        Array.Sort(points, (a,b) => (a[1] - b[1]));
        int res = 1, last = points[0][1];
        for (int i = 1; i < points.Length; i++) {
            // no overlapping, need +1 arrows
            if (points[i][0] > last) {
                res++;
                last = points[i][1];
            }
            else last = Math.Min(points[i][1], last);
        }
        return res;
    }
}

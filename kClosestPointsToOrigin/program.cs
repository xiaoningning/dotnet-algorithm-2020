public class Solution {
    public int[][] KClosest(int[][] points, int K) {
        Array.Sort(points, (p1,p2) => (p1[0]*p1[0] + p1[1]*p1[1]) - (p2[0]*p2[0] + p2[1]*p2[1]));
        int[][] res = new int[K][];
        Array.Copy(points, 0, res, 0, K);
        return res;
    }
}

public class Solution {
    public bool ValidSquare(int[] p1, int[] p2, int[] p3, int[] p4) {
        HashSet<int> s = new HashSet<int>() {
            d(p1,p2),
            d(p1,p3),
            d(p1,p4),
            d(p2,p3),
            d(p2,p4),
            d(p3,p4),
        };
        // edge value and diag value;
        // no 0 edge
        return !s.Contains(0) && s.Count() == 2;
    }
    int d (int[] a, int[] b) {
        return (a[0] - b[0]) * (a[0] - b[0]) + (a[1] - b[1]) * (a[1] - b[1]);
    }
}

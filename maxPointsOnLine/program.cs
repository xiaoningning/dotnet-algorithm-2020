public class Solution {
    public int MaxPoints(int[][] points) {
        int res = 0;
        for (int i = 0; i < points.Length; ++i) {
            var m = new Dictionary<Tuple<int, int>, int> ();
            int duplicate = 1;
            for (int j = i + 1; j < points.Length; ++j) {
                if (points[i][0] == points[j][0] 
                    && points[i][1] == points[j][1]) {
                    ++duplicate; continue;
                } 
                int dx = points[j][0] - points[i][0];
                int dy = points[j][1] - points[i][1];
                // double might not be accurate in points
                // to void divide, use greatest common divisor 
                int d = gcd(dx, dy);
                var k = new Tuple<int,int>(dx/d, dy/d);
                if (!m.ContainsKey(k)) m.Add(k, 0);
                ++m[k];
            }
            res = Math.Max(res, duplicate);
            foreach (var kv in m) {
                res = Math.Max(res, kv.Value + duplicate);
            }
        }
        return res;
    }
    int gcd(int a, int b) {
        return (b == 0) ? a : gcd(b, a % b);
    }
}

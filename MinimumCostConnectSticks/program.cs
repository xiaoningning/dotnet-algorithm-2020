public class Solution {
    public int ConnectSticks(int[] sticks) {
        var a = new List<int>(sticks);
        a.Sort();
        int res = 0;
        while (a.Count > 1) {
            int x = a[0], y = a[1];
            a.RemoveAt(0); a.RemoveAt(0);
            res += x + y;
            a.Add(x+y);
            a.Sort();
        }
        return res;
    }
}

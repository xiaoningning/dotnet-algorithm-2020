public class Solution {
    public int NthUglyNumber(int n) {
        var res= new List<int>(){1};
        int i2 = 0, i3 = 0, i5 = 0;
        while (res.Count < n) {
            int m2 = res[i2] * 2, m3 = res[i3] * 3, m5 = res[i5] * 5;
            int mn = new int[]{m2, m3, m5}.Min();
            if (mn == m2) ++i2;
            if (mn == m3) ++i3;
            if (mn == m5) ++i5;
            res.Add(mn);
        }
        return res.Last();
    }
}

public class Solution {
    public IList<int> MajorityElement(int[] nums) {
        var res = new List<int>();
        // cnt > n/3 => at most 2 numbers
        int a = 0, b = 0, cnt1 = 0, cnt2 = 0, n = nums.Length;
        foreach (int num in nums) {
            if (num == a) ++cnt1;
            else if (num == b) ++cnt2;
            else if (cnt1 == 0) { a = num; cnt1 = 1; }
            else if (cnt2 == 0) { b = num; cnt2 = 1; }
            else { --cnt1; --cnt2; }
        }
        // recount
        cnt1 = cnt2 = 0;
        foreach (int num in nums) {
            if (num == a) ++cnt1;
            else if (num == b) ++cnt2;
        }
        if (cnt1 > n / 3) res.Add(a);
        if (cnt2 > n / 3) res.Add(b);
        return res;
    }
}

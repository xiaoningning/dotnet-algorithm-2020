public class Solution {
    public int[] DiStringMatch(string S) {
        var res = new List<int>();
        int mn = 0, mx = S.Length;
        foreach (var c in S) {
            if (c == 'I') res.Add(mn++);
            else res.Add(mx--);
        }
        res.Add(mx); // add the last
        return res.ToArray();
    }
}

public class Solution {
    public bool IsAdditiveNumber(string num) {
        bool res = false;
        List<long> o = new List<long>();
        helper(num, 0, o, ref res);
        return res;
    }
    void helper(string num, int start, List<long> o, ref bool res) {
        if (res) return;
        if (start >= num.Length) {
            if (o.Count >= 3) res = true; 
            return;
        }
        for (int i = start; i < num.Length; ++i) {
            string str = num.Substring(start, i - start + 1);
            // >19 will over flow int64 
            if ((str.Length > 1 && str[0] == '0') || str.Length > 19) break;
            long curNum = Int64.Parse(str);
            int size = o.Count;
            if (size >= 2 && curNum > o[size-1] + o[size-2]) break;
            if (size >= 2 && curNum != o[size - 1] + o[size - 2]) continue;
            o.Add(curNum);
            helper(num, i + 1, o, ref res);
            o.RemoveAt(o.Count - 1);
        }
    }
}

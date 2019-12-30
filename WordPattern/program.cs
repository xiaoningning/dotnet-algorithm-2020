public class Solution {
    public bool WordPattern(string pattern, string str){
        var m1 = new Dictionary<char, int>();
        var m2 = new Dictionary<string, int>();
        var strArr = str.Split(' ');
        int i = 0, n = pattern.Length;
        for (; i < strArr.Length; i++) {
            if (i == n) return false;
            if (!m1.ContainsKey(pattern[i])) m1.Add(pattern[i], i);
            if (!m2.ContainsKey(strArr[i])) m2.Add(strArr[i], i);
            if (m1[pattern[i]] != m2[strArr[i]]) return false;
        }   
        return i == n;
    }
}

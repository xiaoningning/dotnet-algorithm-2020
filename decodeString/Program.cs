public class Solution {
    public string DecodeString(string s) {
        int i = 0;
        return Helper(s, ref i);                
    }
    string Helper(string s, ref int i){
        string res = string.Empty;
        int n = s.Length;
        while (i < n && s[i] != ']') {
            if (s[i] < '0' || s[i] > '9') res += s[i++];
            else{
                int cnt = 0;
                while (i < n && s[i] >= '0' && s[i] <= '9') {
                    cnt = cnt * 10 + s[i++] - '0';
                }
                i++; // skip '['
                string t = Helper(s, ref i);
                i++; // skip ']'
                while (cnt-- > 0) res += t;
            }
        }
        return res;
    }
    
    public string DecodeString1(string s) {
        string t = string.Empty;
        var s_num = new Stack<int>();
        var s_str = new Stack<string>();
        int cnt = 0;
        for (int i = 0; i < s.Length; ++i) {
            if (s[i] >= '0' && s[i] <= '9') {
                cnt = 10 * cnt + s[i] - '0';
            } else if (s[i] == '[') {
                s_num.Push(cnt);
                s_str.Push(t);
                cnt = 0;
                t = string.Empty;
            } else if (s[i] == ']') {
                int k = s_num.Pop();
                string tmp = s_str.Pop();
                while (k-- > 0) tmp += t;
                t = tmp;
            } else { // a-Z
                t += s[i];
            }
        }
        return s_str.Count == 0 ? t : s_str.Pop();                
    }
}

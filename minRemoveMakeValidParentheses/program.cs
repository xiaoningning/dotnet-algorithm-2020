public class Solution {
    public string MinRemoveToMakeValid(string s) {
        var arr = s.ToCharArray();
        var st = new Stack<int>();
        for (int i = 0; i < arr.Length; ++i) {
            if (s[i] == '(') st.Push(i);
            if (s[i] == ')') {
                if (st.Any()) st.Pop();
                else arr[i] = '*';
            }
        }
        while (st.Any()) arr[st.Pop()] = '*';
        return new string(arr).Replace("*","");
    }
}

public class Solution {
    public bool IsLongPressedName(string name, string typed) {
        int i = 0, n = name.Length, m = typed.Length;
        for (int j = 0; j < m; j++) {
            if (i < n && name[i] == typed[j]) i++;
            else if ( j == 0 || typed[j] != typed[j-1]) return false;
        }
        return i == n;
    }
}

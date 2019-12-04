public class Solution {
    public bool IsValidSudoku(char[][] board) {
        var st = new HashSet<string>();
        for (int i = 0; i < 9; ++i) {
            for (int j = 0; j < 9; ++j) {
                if (board[i][j] == '.') continue;
                string t = "(" + board[i][j] + ")";
                string row = i + t, col = t + j, cell = i / 3 + t + j / 3;
                if (st.Contains(row) || st.Contains(col) || st.Contains(cell)) return false;
                st.Add(row);
                st.Add(col);
                st.Add(cell);
            }
        }
        return true;
    }
}

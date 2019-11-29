public class Solution {
    public char[][] UpdateBoard(char[][] board, int[] click) {
        if (!board.Any() || !board[0].Any()) return new char[][]{};
        int m = board.Length, n = board[0].Length;
        var q = new Queue<int[]>(); q.Enqueue(new int[]{click[0], click[1]});
        while (q.Any()) {
            var t = q.Dequeue();
            int row = t[0], col = t[1], cnt = 0;
            List<int[]> neighbors = new List<int[]>();
            if (board[row][col] == 'M') board[row][col] = 'X';
            else {
                // 4 directions
                for (int i = -1; i < 2; ++i) {
                    for (int j = -1; j < 2; ++j) {
                        int x = row + i, y = col + j;
                        if (x < 0 || x >= m || y < 0 || y >= n) continue;
                        if (board[x][y] == 'M') ++cnt;
                        else if (cnt == 0 && board[x][y] == 'E') neighbors.Add(new int[]{x, y});
                    }
                }
            }
            if (cnt > 0) board[row][col] = (char)(cnt + '0');
            else {
                foreach (var a in neighbors) {
                    board[a[0]][a[1]] = 'B';
                    q.Enqueue(a);
                }
            }
        }
        return board;
    }
}

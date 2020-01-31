public class Solution {
    public int SnakesAndLadders(int[][] board) {
        int n = board.GetLength(0), res = 0;
        var q = new Queue<int>();
        var visited = new bool[n*n + 1];
        q.Enqueue(1);
        visited[1] = true;
        while (q.Count != 0) {
            int size = q.Count;
            // BFS for the minimal
            for (int k = size; k > 0; --k) {
                int num = q.Dequeue();
                if (num == n * n) return res;
                for (int i = 1; i <= 6 && num + i <= n * n; ++i) {
                    int[] pos = GetPosition(num + i, n);
                    int next = board[pos[0]][pos[1]] == -1 ? (num + i) : board[pos[0]][pos[1]];
                    if (visited[next]) continue;
                    visited[next] = true;
                    q.Enqueue(next);
                }
            }
            ++res;
        }
        return -1;
    }
    
    int[] GetPosition(int num, int n) {
        // snake order, left -> right, then right->left
        // i at board[n-1][0]
        int x = (num - 1) / n, y = (num - 1) % n;
        if (x % 2 == 1) y = n - 1 - y;
        x = n - 1 - x;
        return new int[]{x, y};
    }
}

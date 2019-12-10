public class Solution {
    public int SlidingPuzzle(int[][] board) {
        // 123
        // 450
        string target = "123450";
        string start = "";
        for (int i = 0; i < board.Length; i++)
            for (int j = 0; j < board[0].Length; j++)
                start += board[i][j];
        var visited = new HashSet<string>(){start}; 
        var q = new Queue<string>(); q.Enqueue(start);
        // moving directions in string format of idx
        int[][] dirs = new int[6][];
        dirs[0] = new int[]{ 1, 3 };
        dirs[1] = new int[]{ 0, 2, 4 };
        dirs[2] = new int[]{ 1, 5 }; 
        dirs[3] = new int[]{ 0, 4 };
        dirs[4] = new int[]{ 1, 3, 5 };
        dirs[5] = new int[]{ 2, 4 };
        int res = 0;
        //BFS is faster
        while (q.Any()) {
            int size = q.Count;
            for (int i = 0; i < size; i++) {
                string cur = q.Dequeue();
                if (cur == target) return res;
                int zero = cur.IndexOf('0');
                // swap if possible
                foreach (int dir in dirs[zero]) {
                    string next = swap(cur, zero, dir);
                    if (visited.Contains(next)) continue;
                    visited.Add(next);
                    q.Enqueue(next);
                }
            }
            res++;
        }
        return -1;
    }
    string swap(string s, int i, int j){
        var a = s.ToCharArray();
        var t = a[i]; a[i] = a[j]; a[j] = t;
        return new string(a);
    }
}

public class Solution {
    public int MinimumMoves(int[][] grid) {
        int n = grid.Length, res = 0;;
        var q = new Queue<int[]>();
        var visited = new HashSet<string>();
        var k = new int[]{0,0,0,1};
        q.Enqueue(k);
        while (q.Any()) {
            int cnt = q.Count;
            while (cnt-- > 0) {
                var t = q.Dequeue();
                if (t.SequenceEqual(new int[]{n-1,n-2,n-1,n-1})) return res;
                if (visited.Add(string.Join(",",t))) {
                    // horizontal    
                    if (t[0] == t[2]) {
                        // right
                        if (t[3] + 1 < n && grid[t[2]][t[3]+1] == 0) 
                            q.Enqueue(new int[]{t[0],t[1]+1,t[2],t[3]+1}); 
                        // down and clockwise
                        if (t[0] + 1 < n && grid[t[0]+1][t[1]] + grid[t[2]+1][t[3]] == 0) {
                            q.Enqueue(new int[]{t[0],t[1],t[0]+1,t[1]}); 
                            q.Enqueue(new int[]{t[0]+1,t[1],t[2]+1,t[3]}); 
                        }
                    } 
                    // vertical t[1] == t[3]
                    if(t[1] == t[3]) {
                        // right
                        if (t[2] + 1 < n && grid[t[2]+1][t[3]] == 0) 
                            q.Enqueue(new int[]{t[0]+1,t[1],t[2]+1,t[3]}); 
                        // up and counter clockwise
                        if (t[1] + 1 < n && grid[t[0]][t[1]+1] + grid[t[2]][t[3]+1] == 0) {
                            q.Enqueue(new int[]{t[0],t[1],t[0],t[3]+1}); 
                            q.Enqueue(new int[]{t[0],t[1]+1,t[2],t[3]+1}); 
                        }
                    }
                }
            }
            res++;
        }
        // O(n^2)
        return -1;
    }
}

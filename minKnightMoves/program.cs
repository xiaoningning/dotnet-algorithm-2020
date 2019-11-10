public class Solution {
    public int MinKnightMoves0(int x, int y) {
        // Use the symmetric property.
        x = Math.Abs(x); y = Math.Abs(y); 
        var dirs = new int[8,2]{{-1,-2},{-2,-1},{-2,1},{-1,2},{1,2},{2,1},{2,-1},{1,-2}};
        var q = new Queue<string>(); 
        var visited = new HashSet<string>();
        visited.Add(x+"-"+y);
        q.Enqueue(x+"-"+y);
        int res = 0;
        //BFS, TLE for some reason
        while (q.Any()) {
            int size = q.Count;
            for (int s = 0; s < size; s++) {
                var t = q.Dequeue();
                int i = Int32.Parse(t.Split('-')[0]);
                int j = Int32.Parse(t.Split('-')[1]);
                if (i == 0 && j == 0) return res;
                for (int d = 0; d < dirs.GetLength(0); d++) {
                    int a = Math.Abs(i + dirs[d,0]); 
                    int b = Math.Abs(j + dirs[d,1]);
                    if(!visited.Contains(a+"-"+b)) {
                        visited.Add(a+"-"+b);
                        q.Enqueue(a+"-"+b);
                    }
                }
            }
            res++; // per level
        }
        return -1;
    }
    
    public int MinKnightMoves(int x, int y) {
        var cache = new Dictionary<string, int>();
        cache.Add(0+"-"+0,0);
        cache.Add(1+"-"+0,3);
        cache.Add(0+"-"+1,3);
        cache.Add(1+"-"+1,2);
        return dfs(Math.Abs(x), Math.Abs(y), cache);
    }
    // if no cache, then TLE
    int dfs(int x, int y, Dictionary<string, int> cache) {
        if (cache.ContainsKey(x+"-"+y)) return cache[x+"-"+y];
        int res = Math.Min(dfs(Math.Abs(x-1), Math.Abs(y-2), cache),
                        dfs(Math.Abs(x-2), Math.Abs(y-1), cache)) + 1;
        cache[x+"-"+y] = res;
        return res;
    }
}

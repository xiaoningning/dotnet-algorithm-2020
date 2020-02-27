public class Solution {
    public bool IsBipartite(int[][] graph) {
        int n = graph.GetLength(0);
        int[] color = new int[n];
        Queue<int> q = new Queue<int>();
        for(int i = 0; i < n; i++){
            if (color[i] != 0) continue;
            color[i] = 1;
            q.Enqueue(i);
            while (q.Any()){
                int t = q.Dequeue();
                foreach(int node in graph[t]){
                    if (color[node] == color[t]) return false;
                    if (color[node] == 0){
                        color[node] = -1 * color[t];
                        q.Enqueue(node);
                    }
                }
            }
        }
        // O(V+E)
        return true;
    }
}

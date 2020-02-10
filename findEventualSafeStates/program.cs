public class Solution {
    public IList<int> EventualSafeNodes(int[][] graph) {
        var res = new List<int>();
        if(graph == null || graph.Length == 0)  return res;
        
        int nodeCount = graph.Length;
        int[] color = new int[nodeCount];
        
        for(int i = 0;i < nodeCount;i++){
            if(dfs(graph, i, color)) res.Add(i);
        }
        // O(V+E)
        return res;
    }
    bool dfs(int[][] graph, int start, int[] color) {
        if(color[start] != 0) return color[start] == 1;
        
        color[start] = 2; // unsafe
        foreach (int newNode in graph[start]){
            if(!dfs(graph, newNode, color)) return false;
        }
        // all directed nodes are safe
        color[start] = 1; // safe
        
        return true;
    }
}

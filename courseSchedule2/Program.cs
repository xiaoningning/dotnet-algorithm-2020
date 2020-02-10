public class Solution {
    public int[] FindOrder(int numCourses, int[][] prerequisites) {
        // key: from value: to 
        Dictionary<int, List<int>> prereq = new Dictionary<int, List<int>>();
        for(int i = 0; i < prerequisites.GetLength(0); i++){
            int c = prerequisites[i][0];
            int cp = prerequisites[i][1];            
            if(!prereq.ContainsKey(cp)) prereq[cp] = new List<int>();
            prereq[cp].Add(c);
        }
        var visited = new int[numCourses];
        List<int> res = new List<int>();
        for (int i = 0; i < numCourses; i++) {
             if (!canFinishDFS(prereq, visited, i, res)) return new int[]{};
        }
        // O(n) Topological sort
        res.Reverse();
        return res.ToArray(); 
    }
    
    bool canFinishDFS(Dictionary<int, List<int>> g, int[] visited, int i, List<int> res){
        // -1 conflict, 1 visited, 0 not visited
        if (visited[i] == -1) return false;
        if (visited[i] == 1) return true;
        visited[i] = -1;
        if (g.ContainsKey(i))  {
            foreach(int j in g[i]) {
                if (!canFinishDFS(g, visited, j, res)) return false;
            }            
        }
        visited[i] = 1;
        res.Add(i);
        return true;
    }
    
    public int[] FindOrder1(int numCourses, int[,] prerequisites) {
        // key: from value: to 
        Dictionary<int, List<int>> prereq = new Dictionary<int, List<int>>();
        int[] degree = new int[numCourses];
        List<int> res = new List<int>();
        for(int i = 0; i < prerequisites.GetLength(0); i++){
            int c = prerequisites[i,0];
            int cp = prerequisites[i,1];            
            if(!prereq.ContainsKey(cp)) prereq[cp] = new List<int>();
            prereq[cp].Add(c);
            degree[c]++;
        }
        // course wiht not any prereq 
        Queue<int> q = new Queue<int>();
        for(int i = 0; i < numCourses; i++){
            if(degree[i] == 0) q.Enqueue(i);    
        }
        while(q.Count != 0){
            int t = q.Dequeue();
            res.Add(t);
            if (prereq.ContainsKey(t)){
                foreach(int i in prereq[t]){
                    degree[i]--;
                    if(degree[i] == 0) q.Enqueue(i);
                }
            }
        }
        return res.Count == numCourses ? res.ToArray() : new int[]{};        
    } 
}

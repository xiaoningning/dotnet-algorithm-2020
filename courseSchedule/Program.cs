public class Solution {
    public bool CanFinish(int numCourses, int[][] prerequisites) {
        // key: from value: to 
        Dictionary<int, List<int>> prereq = new Dictionary<int, List<int>>();
        for(int i = 0; i < prerequisites.GetLength(0); i++){
            int c = prerequisites[i][0];
            int cp = prerequisites[i][1];            
            if(!prereq.ContainsKey(cp)) prereq[cp] = new List<int>();
            prereq[cp].Add(c);
        }
        var visited = new int[numCourses];
        for (int i = 0; i < numCourses; i++) {
             if (!canFinishDFS(prereq, visited, i)) return false;
        }
        return true;
    }
    bool canFinishDFS(Dictionary<int, List<int>> g, int[] visited, int i){
        // -1 conflict, 1 visited, 0 not visited
        if (visited[i] == -1) return false;
        if (visited[i] == 1) return true;
        if (!g.ContainsKey(i)) return true;
        visited[i] = -1;
        foreach(int j in g[i]) {
            if (!canFinishDFS(g, visited, j)) return false;
        }
        visited[i] = 1;
        return true;
    }
    public bool CanFinish2(int numCourses, int[,] prerequisites) {
        // key: from value: to 
        Dictionary<int, List<int>> prereq = new Dictionary<int, List<int>>();
        int[] inDegrees = new int[numCourses];
        for(int i = 0; i < prerequisites.GetLength(0); i++){
            int c = prerequisites[i,0];
            int cp = prerequisites[i,1];            
            if(!prereq.ContainsKey(cp)) prereq[cp] = new List<int>();
            prereq[cp].Add(c);
            inDegrees[c]++;
        }
        Queue<int> q = new Queue<int>();
        for (int i = 0; i < numCourses; i ++) {
            if (inDegrees[i] == 0) q.Enqueue(i);
        }
        // BFS
        while (q.Count != 0) {
            int t = q.Dequeue();
            foreach (int c in prereq[t]) {
                inDegrees[c]--;
                if (inDegrees[c] == 0) q.Enqueue(c);
            }
        }
        for (int i = 0; i < numCourses; i ++) {
            if (inDegrees[i] != 0) return false;;
        }
        return true;        
    }
    
    public bool CanFinish1(int numCourses, int[,] prerequisites) {
        // key: from value: to 
        Dictionary<int, List<int>> prereq = new Dictionary<int, List<int>>();
        for(int i = 0; i < prerequisites.GetLength(0); i++){
            int c = prerequisites[i,0];
            int cp = prerequisites[i,1];            
            if(!prereq.ContainsKey(cp)) prereq[cp] = new List<int>();
            prereq[cp].Add(c);
        }
        bool[] visited = new bool[numCourses];
        for(int i = 0; i < numCourses; i++){
            // DFS check
            if(!CheckPreReq(prereq, visited, i)) return false;    
        }
        return true;        
    }
    
    bool CheckPreReq(Dictionary<int, List<int>> prereq, bool[] visited, int i){
        if (visited[i]) return false;
        else visited[i] = true;
        
        if (prereq.ContainsKey(i)){
            foreach(int n in prereq[i]){                
                if(!CheckPreReq(prereq, visited, n)) return false;
            }    
        }
        visited[i] = false;
        return true;
    }
}

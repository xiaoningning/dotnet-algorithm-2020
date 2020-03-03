public class Solution {
    public IList<IList<string>> FindLadders(string beginWord, string endWord, IList<string> wordList) {
        var dict = new HashSet<string>(wordList);
        var res = new List<IList<string>>();
        var q = new Queue<List<string>>();
        var path = new List<string>(){ beginWord };
        var visited = new HashSet<string>();            
        q.Enqueue(path);
        int level = 1, minLevel = Int32.MaxValue;

        while(q.Any()){
            var p = q.Dequeue();
            if(p.Count > level){
                foreach(string w in visited) dict.Remove(w);
                visited.Clear();
                level = p.Count;    
            } 
            if(level > minLevel) break;
            string last = p.Last();
            for (int i = 0; i < last.Length; ++i) {
                char[] newChars = last.ToCharArray();
                for (char ch = 'a'; ch <= 'z'; ++ch) {
                    newChars[i] = ch;
                    string newLast = new string(newChars);
                    if(!dict.Contains(newLast)) continue;
                    // remove visited word from dict later                        
                    visited.Add(newLast);
                    // need a new path obj
                    var nextPath = new List<string>(p);
                    nextPath.Add(newLast);
                    if (newLast == endWord) {
                        res.Add(nextPath);
                        minLevel = level;
                    }
                    else q.Enqueue(nextPath);
                }                
            }
        }
        return res;
    }
}

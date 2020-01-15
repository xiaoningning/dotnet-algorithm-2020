public class Solution {
    public IList<int> FindNumOfValidWords(string[] words, string[] puzzles) {
        var map = new Dictionary<int, int>();
        foreach (string w in words){
            int mask = 0; // bit mask
            for(int i = 0; i < w.Length; i++)
                mask |= 1 << (w[i] - 'a');
            map[mask] = map.GetValueOrDefault(mask, 0) + 1;
        }
        var res = new List<int>();
        foreach (string p in puzzles){
            // all combination with 1st letter
            var t = new HashSet<int>(){1 << (p[0] - 'a')};
            for(int i = 1; i < p.Length; i++) {
                var level = new HashSet<int>(t);
                foreach(int m in level) {
                    int m1 = m | 1 << (p[i] - 'a');
                    t.Add(m1);  
                } 
            }
            int cnt = 0;
            foreach(var m in t) cnt += map.GetValueOrDefault(m,0);
            res.Add(cnt);
        }
        return res;
    }
}

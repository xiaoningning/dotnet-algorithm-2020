public class LogSystem {
    List<Tuple<int, string>> timestamps;
    string[] units;
    int[] indices;
    public LogSystem() {
        units = new string[]{"Year", "Month", "Day", "Hour", "Minute", "Second"};
        // length of timestamp
        // 2017:01:01:23:59:59
        indices = new int[]{4, 7, 10, 13, 16, 19}; 
        timestamps = new List<Tuple<int,string>>();
    }
    
    public void Put(int id, string timestamp) {
        timestamps.Add(new Tuple<int, string>(id, timestamp));
    }
    
    public IList<int> Retrieve(string s, string e, string gra) {
        var res = new List<int>();
        var idx = indices[Array.IndexOf(units, gra)];
        foreach (var p in timestamps) {
            string t = p.Item2;
            if (t.Substring(0, idx).CompareTo(s.Substring(0, idx)) >= 0 && t.Substring(0, idx).CompareTo(e.Substring(0, idx)) <= 0) {
                res.Add(p.Item1);
            }
        }
        return res;
    }
}

/**
 * Your LogSystem object will be instantiated and called as such:
 * LogSystem obj = new LogSystem();
 * obj.Put(id,timestamp);
 * IList<int> param_2 = obj.Retrieve(s,e,gra);
 */

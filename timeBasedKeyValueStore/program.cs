public class TimeMap {
    Dictionary<string, List<Data>> map;
    /** Initialize your data structure here. */
    public TimeMap() {
        map = new Dictionary<string, List<Data>>();
    }
    // timestamps for all TimeMap.set operations are strictly increasing
    public void Set(string key, string value, int timestamp) {
        if (!map.ContainsKey(key)) map.Add(key, new List<Data>());
        map[key].Add(new Data(value, timestamp));
    }
    
    public string Get(string key, int timestamp) {
        if (!map.ContainsKey(key)) return "";
        return BinarySearch(map[key], timestamp);
    }
    // linq upper bound TLE
    string BinarySearch1(List<Data> list, int timestamp) {
        var res = list.Where(d => d.time <= timestamp).OrderBy(d => d.time);
        if (res.Any()) return res.Last().val;
        else return "";
    }
    string BinarySearch(List<Data> list, int timestamp) {
        int low = 0, high = list.Count - 1;
        while (low < high) {
            int mid = (low + high) / 2;
            if (list[mid].time == timestamp) return list[mid].val;
            if (list[mid].time < timestamp) {
                if (list[mid+1].time > timestamp) return list[mid].val;
                low = mid + 1;
            }
            else high = mid - 1;
        }
        return list[low].time <= timestamp ? list[low].val : "";
    }
}

public class Data {
    public string val;
    public int time;
    public Data(string val, int time) {
        this.val = val;
        this.time = time;
    }
}

/**
 * Your TimeMap object will be instantiated and called as such:
 * TimeMap obj = new TimeMap();
 * obj.Set(key,value,timestamp);
 * string param_2 = obj.Get(key,timestamp);
 */

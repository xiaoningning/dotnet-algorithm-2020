public class LFUCache {
    private int capacity = 0;
    private Dictionary<int, int> freq; // key -> cnt
    private Dictionary<int, int> cache; // key -> value
    private Dictionary<int, List<int>> freqMap; // cnt -> key
    private int minFreq;
    public LFUCache(int capacity) {
        this.capacity = capacity;
        freq = new Dictionary<int, int>();
        cache = new Dictionary<int, int>();
        freqMap = new Dictionary<int, List<int>>();
        minFreq = 0;
    }

    public int Get(int key) {
        if(!cache.ContainsKey(key)) return -1;
        else {                                                              
            int cnt = freq[key];                
            freqMap[cnt].Remove(key);
            if (cnt == minFreq && freqMap[minFreq].Count == 0) {
                freqMap.Remove(minFreq);
                minFreq++;
            }
            cnt++;
            freq[key] = cnt;
            if (!freqMap.ContainsKey(cnt)) freqMap.Add(cnt, new List<int>());
            freqMap[cnt].Insert(0, key);
            return cache[key];        
        }     
    }

    public void Put(int key, int value) {
        if (capacity <= 0) return;
        if (Get(key) != -1){
            cache[key] = value;                
        }
        else {
            if (cache.Count == capacity) {
                int evitKey = freqMap[minFreq].Last();
                freqMap[minFreq].Remove(evitKey);
                cache.Remove(evitKey);
            }
            cache.Add(key, value);
            minFreq = 1;
            freq[key] = minFreq;
            if (!freqMap.ContainsKey(minFreq)) freqMap.Add(minFreq, new List<int>());
            freqMap[minFreq].Insert(0, key);          
        }
    }
}

/**
 * Your LFUCache object will be instantiated and called as such:
 * LFUCache obj = new LFUCache(capacity);
 * int param_1 = obj.Get(key);
 * obj.Put(key,value);
 */

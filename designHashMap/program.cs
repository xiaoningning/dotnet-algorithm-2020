public class MyHashMap {

    /** Initialize your data structure here. */
    public MyHashMap() {
        // use 2d array to save some space
        data = new int[1000][];
        for (int i = 0; i < 1000; i++) data[i] = new int[0];
    }
    
    /** value will always be non-negative. */
    public void Put(int key, int value) {
        int hashKey = key % 1000;
        if (data[hashKey].Length == 0) { 
            data[hashKey] = new int[1000]; 
            Array.Fill(data[hashKey], -1);
        }
        data[hashKey][key / 1000] = value;
    }
    
    /** Returns the value to which the specified key is mapped, or -1 if this map contains no mapping for the key */
    public int Get(int key) {
        int hashKey = key % 1000;
        if (data[hashKey].Length != 0) {
            return data[hashKey][key / 1000];
        }
        return -1;
    }
    
    /** Removes the mapping of the specified value key if this map contains a mapping for the key */
    public void Remove(int key) {
        int hashKey = key % 1000;
        if (data[hashKey].Length != 0) {
            data[hashKey][key / 1000] = -1;
        }
    }
    int[][] data;
}

/**
 * Your MyHashMap object will be instantiated and called as such:
 * MyHashMap obj = new MyHashMap();
 * obj.Put(key,value);
 * int param_2 = obj.Get(key);
 * obj.Remove(key);
 */

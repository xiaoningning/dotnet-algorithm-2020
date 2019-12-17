public class PhoneDirectory {
    int mx;
    Queue<int> q;
    HashSet<int> used;
    
    /** Initialize your data structure here
        @param maxNumbers - The maximum numbers that can be stored in the phone directory. */
    public PhoneDirectory(int maxNumbers) {
        mx = maxNumbers;
        q = new Queue<int>();
        used = new HashSet<int>();
        for (int i = 0; i < maxNumbers; i++) q.Enqueue(i);
    }
    
    /** Provide a number which is not assigned to anyone.
        @return - Return an available number. Return -1 if none is available. */
    public int Get() {
        if (!q.Any()) return -1;
        int num = q.Dequeue();
        used.Add(num);
        return num;
    }
    
    /** Check if a number is available or not. */
    public bool Check(int number) {
        return !used.Contains(number);
    }
    
    /** Recycle or release a number. */
    public void Release(int number) {
        if (!used.Contains(number)) return;
        used.Remove(number);
        q.Enqueue(number);
    }
}

/**
 * Your PhoneDirectory object will be instantiated and called as such:
 * PhoneDirectory obj = new PhoneDirectory(maxNumbers);
 * int param_1 = obj.Get();
 * bool param_2 = obj.Check(number);
 * obj.Release(number);
 */

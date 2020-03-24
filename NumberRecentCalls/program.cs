public class RecentCounter {
    Queue<int> q;
    public RecentCounter() {
        q = new Queue<int>();
    }
    
    public int Ping(int t) {
        while (q.Any()) {
            if (q.Peek() + 3000 >= t) break; 
            q.Dequeue();
        }
        q.Enqueue(t);
        return q.Count;
    }
}

/**
 * Your RecentCounter object will be instantiated and called as such:
 * RecentCounter obj = new RecentCounter();
 * int param_1 = obj.Ping(t);
 */

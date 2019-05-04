public class HitCounter {
    Queue<int> q;
    /** Initialize your data structure here. */
    public HitCounter() {
        q = new Queue<int>();
    }
    
    /** Record a hit.
        @param timestamp - The current timestamp (in seconds granularity). */
    public void Hit(int timestamp) {
        q.Enqueue(timestamp);
    }
    
    /** Return the number of hits in the past 5 minutes.
        @param timestamp - The current timestamp (in seconds granularity). */
    public int GetHits(int timestamp) {
        while (q.Count != 0 && timestamp - q.Peek() >= 300) q.Dequeue();
        return q.Count;
    }
}

/**
 * Your HitCounter object will be instantiated and called as such:
 * HitCounter obj = new HitCounter();
 * obj.Hit(timestamp);
 * int param_2 = obj.GetHits(timestamp);
 */

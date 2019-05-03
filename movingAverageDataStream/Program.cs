public class MovingAverage {
    Queue<int> q = new Queue<int>();
    int k = 0;
    int sum = 0;
    /** Initialize your data structure here. */
    public MovingAverage(int size) {
        k = size;  
    }
    
    public double Next(int val) {
        q.Enqueue(val);
        while (q.Count > k) {
            int t = q.Dequeue();
            sum -= t;
        }
        int cnt = q.Count;
        sum += val;
        return (double) sum/cnt;
    }
}

/**
 * Your MovingAverage object will be instantiated and called as such:
 * MovingAverage obj = new MovingAverage(size);
 * double param_1 = obj.Next(val);
 */

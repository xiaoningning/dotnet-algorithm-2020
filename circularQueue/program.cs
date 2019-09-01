public class MyCircularQueue {

    /** Initialize your data structure here. Set the size of the queue to be k. */
    public MyCircularQueue(int k) {
        data = new int[k];
        size = k; cnt = 0; tail = 0; head = 0; 
    }
    
    /** Insert an element into the circular queue. Return true if the operation is successful. */
    public bool EnQueue(int value) {
        if (IsFull()) return false;
        data[tail] = value;
        tail = (tail + 1) % size;
        cnt++;
        return true;
    }
    
    /** Delete an element from the circular queue. Return true if the operation is successful. */
    public bool DeQueue() {
        if (IsEmpty()) return false;
        head = (head + 1) % size;
        cnt--;
        return true;
    }
    
    /** Get the front item from the queue. */
    public int Front() {
        return IsEmpty() ? -1 : data[head];
    }
    
    /** Get the last item from the queue. */
    public int Rear() {
        // tail -1 could over the boundary
        // so (tail - 1 + size) % size
        return IsEmpty() ? -1 : data[(tail - 1 + size) % size];
    }
    
    /** Checks whether the circular queue is empty or not. */
    public bool IsEmpty() {
        return cnt == 0;
    }
    
    /** Checks whether the circular queue is full or not. */
    public bool IsFull() {
        return cnt == size;
    }
    
    int[] data;
    int size, cnt, head, tail;
}

/**
 * Your MyCircularQueue object will be instantiated and called as such:
 * MyCircularQueue obj = new MyCircularQueue(k);
 * bool param_1 = obj.EnQueue(value);
 * bool param_2 = obj.DeQueue();
 * int param_3 = obj.Front();
 * int param_4 = obj.Rear();
 * bool param_5 = obj.IsEmpty();
 * bool param_6 = obj.IsFull();
 */

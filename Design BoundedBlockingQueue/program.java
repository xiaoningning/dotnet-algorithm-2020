// import java.util.concurrent.*;

class BoundedBlockingQueue {
    // Locks for blocking and unblocking the queue before push and pop
    Semaphore pushLock, popLock; 
    List<Integer> queue;
    
    public BoundedBlockingQueue(int capacity) {
        pushLock = new Semaphore(capacity); // Block push when capacity of the queue is full
        popLock = new Semaphore(0); // Block pop when queue is empty
        queue = new ArrayList<>();
    }
    
    public void enqueue(int element) throws InterruptedException {
        pushLock.acquire();
        queue.add(element);
        popLock.release();
    }
    
    public int dequeue() throws InterruptedException {
        popLock.acquire();
        int element = queue.remove(0);
        pushLock.release();
        return element;
    }
    
    public int size() throws InterruptedException {
        return queue.size();
    }
}

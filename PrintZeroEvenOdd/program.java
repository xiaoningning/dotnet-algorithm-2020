import java.util.concurrent.*;
class ZeroEvenOdd {
    private int n;
    private Semaphore semaphoreZero, semaphoreEven, semaphoreOdd;
    public ZeroEvenOdd(int n) {
        this.n = n;
        semaphoreZero = new Semaphore(1);
        semaphoreEven = new Semaphore(0);
        semaphoreOdd = new Semaphore(0);
    }

    // printNumber.accept(x) outputs "x", where x is an integer.
    public void zero(IntConsumer printNumber) throws InterruptedException {
        for (int i = 0; i < n; ++i) {
            semaphoreZero.acquire();
            printNumber.accept(0);
            // Alternately release odd() and even().
            (i % 2 == 0 ? semaphoreOdd : semaphoreEven).release(); 
        }
    }

    public void even(IntConsumer printNumber) throws InterruptedException {
        for (int i = 2; i <= n; i += 2) {
            semaphoreEven.acquire();
            printNumber.accept(i);
            semaphoreZero.release();
        }
    }

    public void odd(IntConsumer printNumber) throws InterruptedException {
        for (int i = 1; i <= n; i += 2) {
            semaphoreOdd.acquire();
            printNumber.accept(i);
            semaphoreZero.release();
        }
    }
}

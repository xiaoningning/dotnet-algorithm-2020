import java.util.concurrent.*;
class H2O {
    private Semaphore semO;
    private Semaphore semH;
    public H2O() {
        semO = new Semaphore(0);
        semH = new Semaphore(2);
    }

    public void hydrogen(Runnable releaseHydrogen) throws InterruptedException {
		semH.acquire();
        // releaseHydrogen.run() outputs "H". Do not change or remove this line.
        releaseHydrogen.run();
        semO.release();
    }

    public void oxygen(Runnable releaseOxygen) throws InterruptedException {
        semO.acquire(2);
        // releaseOxygen.run() outputs "H". Do not change or remove this line.
		releaseOxygen.run();
        semH.release(2);       
    }
}

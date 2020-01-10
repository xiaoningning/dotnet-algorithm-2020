import java.util.concurrent.Semaphore;
class FooBar {
    private int n;
    Semaphore rubf = new Semaphore(0);
    Semaphore rubb = new Semaphore(1);

    public FooBar(int n) {
        this.n = n;
    }

    public void foo(Runnable printFoo) throws InterruptedException {
        
        for (int i = 0; i < n; i++) {
            rubb.acquire();
        	// printFoo.run() outputs "foo". Do not change or remove this line.
        	printFoo.run();
            rubf.release();
        }
    }

    public void bar(Runnable printBar) throws InterruptedException {
        
        for (int i = 0; i < n; i++) {
            rubf.acquire();
            // printBar.run() outputs "bar". Do not change or remove this line.
        	printBar.run();
            rubb.release();
        }
    }
}

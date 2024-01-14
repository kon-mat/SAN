package Zadanie5;

public class BinarySemaphoreTest {

    public static void main(String[] args) {
        BinarySemaphore binarySemaphore = new BinarySemaphore();

        // Tworzymy i uruchamiamy kilka wątków, które będą korzystać z semafora
        Thread thread1 = new Thread(() -> {
            try {
                binarySemaphore.acquire();
                System.out.println("Thread 1 acquired the semaphore.");
                Thread.sleep(2000); // Symulacja wykonywanej pracy
                binarySemaphore.release();
                System.out.println("Thread 1 released the semaphore.");
            } catch (InterruptedException e) {
                e.printStackTrace();
            }
        });

        Thread thread2 = new Thread(() -> {
            try {
                binarySemaphore.acquire();
                System.out.println("Thread 2 acquired the semaphore.");
                Thread.sleep(3000); // Symulacja wykonywanej pracy
                binarySemaphore.release();
                System.out.println("Thread 2 released the semaphore.");
            } catch (InterruptedException e) {
                e.printStackTrace();
            }
        });

        Thread thread3 = new Thread(() -> {
            try {
                Thread.sleep(1000); // Trochę czekamy, aby thread1 zajął semafor pierwszy
                binarySemaphore.acquire();
                System.out.println("Thread 3 acquired the semaphore.");
                binarySemaphore.release();
                System.out.println("Thread 3 released the semaphore.");
            } catch (InterruptedException e) {
                e.printStackTrace();
            }
        });

        // Uruchamiamy wątki
        thread1.start();
        thread2.start();
        thread3.start();
    }
}
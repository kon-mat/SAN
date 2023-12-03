package Zadanie2;

public class Main {
	public static void main(String[] args) {
        int x = 0;
        MyThread[] threads = new MyThread[5];

        for (int i = 0; i < threads.length; i++) {
            threads[i] = new MyThread();
            threads[i].start();
        }

        try {
            for (MyThread thread : threads) {
                thread.join(); // Metoda ta zapewnia, że aktualny wątek czeka na zakończenie się wątku, na którym join zostało wywołane.
                System.out.println("x = " + x);
                System.out.println("x = " + x + " + " + thread.getResult());
                x += thread.getResult();
                System.out.println("x = " + x);
            }
        } catch (InterruptedException e) {	// Wyjątek ten sygnalizuje sytuację, w której wątek został przerwany. Wątek może zostać przerwany po wywołaniu na jego instancji metody Thread.interrupt.
            e.printStackTrace();
        }

        System.out.println("Wynik zmiennej x: " + x);
	}
}

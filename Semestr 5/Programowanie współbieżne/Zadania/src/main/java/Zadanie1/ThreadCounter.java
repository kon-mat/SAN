package Zadanie1;

import java.util.Random;

public class ThreadCounter implements Runnable {

	@Override
	public void run() {
		Random random = new Random();
		try {
			while (true) {
				for (int i = 0; i <= 10; i++) {
					System.out.println(Thread.currentThread().getName() + ": " + i);
					Thread.sleep(random.nextInt(1000));	// opóżnienie o losowy czas do 1 sekundy
				}
			}
		} catch (InterruptedException e) {
			e.printStackTrace();
		}

	}

}

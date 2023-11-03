package Third;

public class RaceCondition {
	public static void main(String[] args) throws InterruptedException {
		Counter c = new Counter();
		Runnable r = () -> {
			for (int i = 0; i < 100_000; i++) {
				c.increment();
			}
		};
		
		Thread t1 = new Thread(r);
		Thread t2 = new Thread(r);
		Thread t3 = new Thread(r);
		
		t1.start(); //Metoda start() uruchamia wątek. Bez niej kod wewnątrz interfejsu Runnable nie zostałby wykonany.
		t2.start();
		t3.start();
		
		t1.join(); //Metoda ta zapewnia, że aktualny wątek czeka na zakończenie się wątku, na którym join zostało wywołane.
		t2.join();
		t3.join();
		
		//Ponieważ w aktualnej klasie Counter wykorzystaliśmy blok synchronized, to zawsze otrzymamy wartość 300000
		System.out.println(c.getValue());
		
		//Synchronizacja wątków pozwala na uniknięcie wielu problemów związanych na przykład z wyścigami. Niestety ma też swoje słabe strony. Pamiętaj, że cały kod, który jest w bloku synchronized w danym momencie może być uruchomiony przez maksymalnie jeden wątek. W związku z tym ten fragment kodu traci możliwość równoczesnego uruchomienia na kilku procesorach – spowalnia wykonanie programu wielowątkowego.
		//Taki fragment kodu, który w danym momencie może być użyty przez maksymalnie jeden wątek nazywany jest sekcją krytyczną. Dobrą zasadą jest ograniczanie sekcji krytycznej – im mniej w niej kodu tym większy zysk z użycia wielu wątków.
	}
}
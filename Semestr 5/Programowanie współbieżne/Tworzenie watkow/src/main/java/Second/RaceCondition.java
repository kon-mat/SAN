package Second;

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
		
		//Ze względu na wyścig wątków (ignorowanie pracy poprzedniego wątku przez kolejny) możemy nie otrzymać oczekiwanej wartości 300000
		System.out.println(c.getValue());
	}
}

package konmat.First;

public class Runner {
	public static void main(String[] args) {
		Runnable[] runners = new Runnable[10];
		Thread[] threads = new Thread[10];
		
		for (int i = 0; i < 10; i++) {
			runners[i] = new MyRun(i);
		}
		
		for (int i = 0; i < 10; i++) {
			threads[i] = new Thread(runners[i]);
		}
		
		for (int i = 0; i < 10; i++) {
			threads[i].start();
		}
		
	}
}

package konmat;

public class MultiThread {
	public static void main(String[] args) {
		System.out.println("W przpadku value o tej samej wartosci singleton zostal uzyty poprawnie" + "\n\n" +
				"Wynik:");
		Thread threadAAA = new Thread(new ThreadAAA());
		Thread threadBBB = new Thread(new ThreadBBB());
		threadAAA.start();
		threadBBB.start();
	}
		
	
}

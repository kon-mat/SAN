package konmat;

public class ThreadBBB implements Runnable {

	@Override
	public void run() {
		Singleton singleton = Singleton.getInstance("BBB");
		System.out.println(singleton.value);

	}

}

package konmat;

public class ThreadAAA implements Runnable {

	@Override
	public void run() {
		Singleton singleton = Singleton.getInstance("AAA");
		System.out.println(singleton.value);

	}

}

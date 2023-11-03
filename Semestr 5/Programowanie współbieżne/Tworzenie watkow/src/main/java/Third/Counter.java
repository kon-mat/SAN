package Third;

public class Counter {
	private int value;
	
	public void increment() {
		synchronized (this) {
			value += 1;
		}
	}
	
	public int getValue() {
		return value;
	}
}

package Zadanie1;

public class Main {
	public static void main(String[] args) {
        for (int i = 0; i < 5; i++) {
            Thread thread = new Thread(new ThreadCounter());
            thread.start();
        }
	}
}

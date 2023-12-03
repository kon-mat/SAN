package Zadanie2;

import java.util.Random;

public class MyThread extends Thread {
	private int result;
	
	@Override
	public void run() {
		Random random = new Random();
		int number1 = random.nextInt(10) + 1;
		int number2 = random.nextInt(10) + 1;
		
		result = number1 + number2;
		
		System.out.println("Wątek " + Thread.currentThread().threadId() + ":   " 
				+ number1 + " + " + number2 + " = " + result);
	}
	
	public int getResult() {
		return result;
	}
	
}

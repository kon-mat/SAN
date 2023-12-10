package Zadanie4;

//- Każdy filozof może myśleć do woli, niezależnie od pozostałych.
//- Filozof może zacząć jeść tylko jeśli udało mu się podnieść dwie pałeczki.
//- Pałeczka nie może być podniesiona przez dwóch filozofów w tym samym czasie.
//- Pałeczki podnoszone są pojedynczo, najpierw pałeczka z lewej strony.

import java.util.concurrent.Semaphore;

public class Filozof extends Thread {

	static final int MAX = 5;
	static Semaphore[] paleczka = new Semaphore[MAX];	// Tablica semaforów dla dostepu dla każdej z pałczek
	static Semaphore jadalnia = new Semaphore(MAX - 1);	// Semafor jadalnia	(maksymalnie 4)
	int mojNum;
	
	public Filozof(int nr) {
		mojNum = nr;
	}
	
	@Override
	public void run() {
		
		while (true) {
			
			//	Myślenie
			System.out.println("Myśli... - filozof " + mojNum);
			try {
				Thread.sleep((long) (5000 * Math.random()));	// losowy czas 0-5s
			} catch (InterruptedException e) {
			}
			
			jadalnia.acquireUninterruptibly();	// Filozof uzyskuje dostęp do semaforu jadalnia (przydział pałeczek)
			paleczka[mojNum].acquireUninterruptibly();	// Filozof uzyskuje dostęp do lewej pałeczki
			paleczka[(mojNum + 1) % MAX].acquireUninterruptibly();	// Filozof uzyskuje dostęp do prawej pałeczki
			
			// Jedzenie
			System.out.println("Zaczynam jeść... - filozof " + mojNum);
			try {
				Thread.sleep((long) (3000 * Math.random()));	// losowy czas 0-3s
			} catch (InterruptedException e) {
			}
			System.out.println("Kończę jeść... - filozof " + mojNum);
			
			paleczka[mojNum].release();	// Filozof zwalnia dostęp do lewej pałeczki
			paleczka[(mojNum + 1) % MAX].release();	// Filozof zwalnia dostęp do prawej pałeczki
			
			jadalnia.release();	// Filozof zwalnia dostęp do semaforu jadalnia
		}
	}
	
	
	public static void main(String[] args) {
		
		for (int i = 0; i < MAX; i++) {
			paleczka[i] = new Semaphore(i);
		}
		
		for (int i = 0; i < MAX; i++) {
			(new Filozof(i)).start();
		}
		
	}
}

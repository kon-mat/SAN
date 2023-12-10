package Zadanie3.CzytelnicyIPisarze;

/* ---------[   acquire() vs acquireUninterruptibly()   ]---------
 	acquire() jest przerywalne. Oznacza to, że jeśli wątek A wywoła funkcję acquire() na semaforze,
	a wątek B przerwie wątek A przez wywołanie funkcji interrupt(), to w wątku A zostanie zgłoszony wyjątek InterruptedException.

	acquireUninterruptibly() nie jest przerywalna. Oznacza to, że jeśli wątek A wywoła funkcję acquireUninterruptibly() na semaforze, 
	a wątek B przerwie wątek A wywołując funkcję interrupt(), to nie zostanie zgłoszony wyjątek InterruptedException dla wątku A, 
	a jedynie wątek A będzie miał ustawiony status przerwania po powrocie funkcji acquireUninterruptibly(). */


import java.util.concurrent.Semaphore;

public class Main {

	static final int LICZ_PISA = 2;
	static final int LICZ_CZYT = 9;
	static Semaphore czytelnik_sprawdzam = new Semaphore(1);
	static Semaphore pisarz_sprawdzam = new Semaphore(1);
	static Semaphore chcePisac = new Semaphore(1);
	static Semaphore pisanie = new Semaphore(1);
	static volatile int liczbaCzytelnikow = 0;
	static volatile int liczbaPisarzy = 0;
	
	
	
	static class Czytelnik extends Thread {
		
		private int mojNum;
		
		public Czytelnik(int nr) {
			this.mojNum = nr;
		}
		
		@Override
		public void run() {
			
			while (true) {
				
				try {
					Thread.sleep((long) (5000 * Math.random()));	// losowy czas 0-5s
				} catch (InterruptedException e) {
				}
				
				chcePisac.acquireUninterruptibly();		// czytelnik nabywa dostep do semafora chcePisac (informacja, ze chce uzyskac dostep do zapisu)
				czytelnik_sprawdzam.acquireUninterruptibly();	// czytelnik nabywa dostep do sprawdzania i zmiany liczby czytelnikow
				liczbaCzytelnikow++;
				if (liczbaCzytelnikow == 1) {	// jezeli czytelnik jest pierwszym czytelnikiem nabywajacym dostep
					pisanie.acquireUninterruptibly();	// to nabywa i blokuje on dostep do pisania
				}
				czytelnik_sprawdzam.release();	// czytelnik zwalnia dostep do sprawdzenia i zmiany liczby czytelnikow
				chcePisac.release();	// czytelnik zwalnia dostep do semafora chcePisac
				
				//	Sekcja odczytu
				System.out.println("Start CZYTANIA " + mojNum);	
				
				try {
					Thread.sleep((long) (5000 * Math.random()));	// losowy czas 0-7s
				} catch (InterruptedException e) {
				}
			
				System.out.println("Stop CZYTANIA " + mojNum);
				
				czytelnik_sprawdzam.acquireUninterruptibly();	// czytelnik nabywa dostep do sprawdzania i zmiany liczby czytelnikow
				liczbaCzytelnikow--;
				if (liczbaCzytelnikow == 0) {	// jezeli czytelnik jest ostatnim czytelnikiem posiadajacym dostep
					pisanie.release();	// to zwalnia on dostep do pisania
				}
				czytelnik_sprawdzam.release();	// czytelnik zwalnia dostep do sprawdzenia i zmiany liczby czytelnikow
				
			}
		}	
	}
	
	
	
	static class Pisarz extends Thread {
		
		private int mojNum;
		
		public Pisarz(int nr) {
			this.mojNum = nr;
		}
		
		@Override
		public void run() {
			
			while (true) {
				
				try {
					Thread.sleep((long) (5000 * Math.random()));	// losowy czas 0-5s
				} catch (InterruptedException e) {
				}
				
				pisarz_sprawdzam.acquireUninterruptibly();	// pisarz nabywa dostep do sprawdzania i zmiany liczby pisarzy
				liczbaPisarzy ++;
				if (liczbaPisarzy == 1) {	// jezeli istnieje juz pisarz, ktory ma dostep do zapisu
					chcePisac.acquireUninterruptibly();	// pisarz nabywa dostep do semafora chcePisac (informacja, ze chce uzyskac dostep do zapisu)
				}
				pisarz_sprawdzam.release();	// pisarz zwalnia dostep do sprawdzania i zmiany liczby pisarzy
				pisanie.acquireUninterruptibly();	// pisarz nabywa i blokuje dostep do pisania
				
				//	Sekcja zapisu
				System.out.println("Start PISANIA " + mojNum);	
				
				try {
					Thread.sleep((long) (2000 * Math.random()));	// losowy czas 0-2s
				} catch (InterruptedException e) {
				}
			
				System.out.println("Stop PISANIA " + mojNum);
				
				pisanie.release();	// pisarz zwalnia dostep do pisania
				pisarz_sprawdzam.acquireUninterruptibly();	// pisarz nabywa dostep do sprawdzania i zmiany liczby pisarzy
				liczbaPisarzy --;
				if (liczbaPisarzy == 0) {	// jezeli pisarz byl jedynym pisarzem
					chcePisac.release();	// to zwalnia on dostep do semafora chcePisac
				}
				pisarz_sprawdzam.release();	// pisarz zwalnia dostep do sprawdzania i zmiany liczby pisarzy
				
			}	
		}	
	}
	
	
	
	public static void main(String[] args) {
		
		for (int i = 0; i < LICZ_CZYT; i++) {
			(new Czytelnik(i)).start();
		}
		
		for (int i = 0; i < LICZ_PISA; i++) {
			(new Pisarz(i)).start();
		}
	}
}

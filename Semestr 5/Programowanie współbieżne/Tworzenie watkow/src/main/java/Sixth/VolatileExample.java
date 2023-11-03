package Sixth;

import java.time.Duration;
import java.time.LocalDateTime;
import java.time.temporal.ChronoUnit;

//Java udostępnia jeszcze jeden mechanizm, który pozwala na synchronizację. Mam tu na myśli słowo kluczowe volatile. Specyfikacja języka Java mówi, że każdy odczyt atrybutu poprzedzonego tym słowem kluczowym następuje po jego zapisie. Innymi słowy, modyfikator volatile gwarantuje, że każdy wątek czytający dany atrybut zobaczy najnowszą zapisaną wartość tego atrybutu.
//Dzięki temu możesz osiągnąć synchronizację wartości danego pola pomiędzy wątkami. Musisz jednak uważać na modyfikacje, które nie są atomowe – przed zmianami tego typu volatile niestety Cię nie uchroni. W takim przypadku niezbędna będzie synchronizacja, którą opisałem wcześniej.


public class VolatileExample {
	private static volatile boolean isDone = false; //Bez modyfikator volatile otrzymalibysmy niekonczaca sie petle, poniewaz isDone byloby stale odczytywane jako false, pomimo ukonczenia zadania po 2 sekundach i zmianie wartosci na true
	
	public static void main(String[] args) {
		
		Thread backgroundJob = new Thread(() -> {
			try {
				Thread.sleep(Duration.ofSeconds(2).toMillis());
			} catch (InterruptedException e) {
				throw new RuntimeException(e);
			}
			System.out.println("I'm done with my job!");
			isDone = true;
		});
		
		Thread heavyWorker = new Thread(() -> {
			LocalDateTime start = LocalDateTime.now();
			while (!isDone) {
				// constantly doing some important stuff
			}
			long durationInMillis = ChronoUnit.MILLIS.between(start, LocalDateTime.now());
			System.out.println("I've been notified about finished job after " + durationInMillis + " milliseconds.");
		});
		
		heavyWorker.start();
		backgroundJob.start();
	}
}

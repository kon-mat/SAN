package Fourth;

import java.time.Duration;
import java.util.LinkedList;
import java.util.Queue;
import java.util.Random;

//Ten przykład pokazuje złe praktyki.
//Program działa. Ma jednak pewien subtelny błąd. Zwróć uwagę na wątek konsumenta. Wątek ten działa bez przerwy. Bez przerwy zajmuje czas procesora8. Co więcej, przez większość swojego czasu kręci się wewnątrz pętli sprawdzając czy kolejka jest pusta.

public class NaiveConsumerProducer {
	private static final Random generator = new Random();
	private static final Queue<String> queue = new LinkedList<>();
	
	public static void main(String[] args) {
		int itemCount = 5;
		
		//wątek produkujący dane
		Thread producer = new Thread(() -> {
			for (int i = 0; i < itemCount; i++) {	//Pętla produkuje zadaną liczbę elementów
				try {
					Thread.sleep(Duration.ofSeconds(generator.nextInt(5)).toMillis()); //Metoda sleep() służy do uśpienia wątku. Przekazany parametr mówi o minimalnym czasie, przez który dany wątek będzie uśpiony – nie będzie zajmował czasu procesora. 
				} catch (InterruptedException e) {
					throw new RuntimeException(e);
				}
				synchronized (queue) {
					queue.add("Item no. " + i);	//Dodajemy nowy element. Używamy tu obiektu queue, dzięki temu mamy pewność, że nie nastąpi wyścig podczas dodawania czy usuwania elementów z kolejki.
				}		
			}
		}); //Wątek kończy swoje działanie po wyprodukowaniu wszystkich elementów.
		
		//Wątek konsumujący wyprodukowane elementy.
		Thread consumer = new Thread(() -> {
			//int whileCounter = 0;
			int itemsLeft = itemCount;
			while (itemsLeft > 0) {	//Pętla while, która wykonuje się dopóki oczekiwana liczba elementów nie zostanie pobrana z kolejki.
				//System.out.println(++whileCounter);
				String item;
				synchronized (queue) {
					if (queue.isEmpty()) {
						continue;
					}
					item = queue.poll();
				}
				itemsLeft--;
				System.out.println("Consumer got item: " + item);
			}
		});
		
		consumer.start();
		producer.start();
	}
	
}

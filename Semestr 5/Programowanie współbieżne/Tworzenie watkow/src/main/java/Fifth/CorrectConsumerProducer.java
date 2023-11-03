package Fifth;

import java.time.Duration;
import java.util.LinkedList;
import java.util.Queue;
import java.util.Random;

public class CorrectConsumerProducer {
	private static final Random generator = new Random();
	private static final Queue<String> queue = new LinkedList<>();
	
	public static void main(String[] args) {
		int itemCount = 5;
		
		Thread producer = new Thread(() -> {
			for (int i = 0; i < itemCount; i++) {
				try {
					Thread.sleep(Duration.ofSeconds(generator.nextInt(5)).toMillis());  
				} catch (InterruptedException e) {
					throw new RuntimeException(e);
				}
				synchronized (queue) {
					queue.add("Item no. " + i);
					queue.notify();	//dodajemy powiadomienie informując w ten sposób konsumentów o nowym elemencie.
				}		
			}
		}); 
		
		Thread consumer = new Thread(() -> {
			int itemsLeft = itemCount;
			while (itemsLeft > 0) {	
				String item;
				synchronized (queue) {
					//Specyfikacja języka Java pozwala na fałszywe wybudzenia (ang. spurious wake-ups). Są to wybudzenia, które mogą wystąpić nawet gdy nie było odpowiadającego im powiadomienia – wywołania metody notify. Dlatego właśnie sprawdzenie warunku (queue.isEmpty()) musi być wykonane w pętli.
					while (queue.isEmpty()) {
						try {
							queue.wait();
						} catch (InterruptedException e2) {
							throw new RuntimeException(e2);
						}
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

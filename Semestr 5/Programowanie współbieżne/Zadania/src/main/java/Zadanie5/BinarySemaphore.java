package Zadanie5;

public class BinarySemaphore {
	private boolean isSemaphoreAvailable = true;
	
	public synchronized void acquire() throws InterruptedException {
		while (!isSemaphoreAvailable) {
			wait();		// Czeka, aż semafor będzie dostępny
		}
		isSemaphoreAvailable = false;
	}
	
	public synchronized void release() {
		isSemaphoreAvailable = true;
		notify(); 	// Powiadom inne wątki, że semafor jest dostępny. 
	}
	
}





























/*
acquire(): 
Metoda acquire służy do zdobywania zasobu kontrolowanego przez semafor. 
Jeśli semafor jest dostępny (czyli ustawiony na true), wątek, który wywołuje tę metodę, 
uzyskuje dostęp do zasobu i kontynuuje wykonanie. Jeśli semafor nie jest dostępny (czyli ustawiony na false), 
wątek zostaje zawieszony (przechodzi w stan oczekiwania) do momentu, gdy semafor stanie się dostępny, 
czyli gdy inny wątek zwolni zasób poprzez wywołanie metody release.

release(): 
Metoda release służy do zwalniania zasobu kontrolowanego przez semafor. 
Po wywołaniu tej metody semafor staje się dostępny (ustawiany na true). 
Jeśli jakieś wątki czekały na dostęp do semafora, jedno z nich zostanie wybrane i przejdzie do etapu 
wykonania (w przypadku korzystania z notify) lub wszystkie zaczynają wykonywać się (w przypadku korzystania z notifyAll).

notify(): 
Metoda notify jest używana w kontekście mechanizmu synchronizacji wątków i jest wywoływana na obiekcie monitora. 
W przypadku klasy BinarySemaphore, jest to obiekt tej klasy. notify służy do poinformowania jednego z wątków, 
który jest w stanie oczekiwania (wait), że może kontynuować swoje wykonanie. Jeśli więcej niż jeden wątek oczekuje, 
to nie ma gwarancji, który z nich zostanie wybrany. Użycie notify jest zazwyczaj skuteczne, 
gdy tylko jeden wątek powinien kontynuować pracę po uwolnieniu zasobu.

W przypadku wielu wątków oczekujących na dostęp, zalecane jest stosowanie notifyAll, co powoduje poinformowanie wszystkich wątków, 
które czekają na dostęp do zasobu, że teraz mogą próbować zdobyć ten dostęp. 
Jest to bardziej bezpieczne podejście, które minimalizuje ryzyko zagubienia notyfikacji dla wątków oczekujących
*/
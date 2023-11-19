package konmat.Mediator;

// Interfejs Mediator deklaruje metodę używaną przez komponenty do powiadamiania mediatora o różnych zdarzeniach. 
// Mediator może reagować na te zdarzenia i przekazywać ich wykonanie innym komponentom.
public interface Mediator {
	void Notify(Object sender, String event);
}

package konmat;

//W Javie odroczona inicjalizacja obiektu to technika polegająca na opóźnieniu tworzenia obiektu do momentu, gdy jest on rzeczywiście potrzebny. Pozwala to zaoszczędzić zasoby i zoptymalizować wydajność aplikacji.

public class LazyInitializedObject {
	private Object someObject;
	
	//Używamy bloku synchronized w metodzie inicjalizacji, aby uniknąć problemów z wielowątkowością. To sprawi, że dostęp do inicjalizowanego obiektu będzie blokowany, aż zostanie poprawnie zainicjalizowany.
	public synchronized Object getSomeObject() {
		if (someObject == null) {
			someObject = new Object();
		}
		return someObject;
	}
}

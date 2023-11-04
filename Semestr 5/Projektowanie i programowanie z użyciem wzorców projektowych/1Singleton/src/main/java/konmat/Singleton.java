package konmat;

public final class Singleton {
	private static volatile Singleton instance;
	
	public String value;
	
	private Singleton(String value) {
		this.value = value;
	}

	public static Singleton getInstance(String value) {
		Singleton result = instance;
		if (result != null) {
			return result;
		}
		
		synchronized (Singleton.class) {
			if (instance == null) {
				instance = new Singleton(value);
			}
			return instance;
		}
	}
}





//Notatki
//volatile has semantics for memory visibility. Basically, the value of a volatile field becomes visible to all readers (other threads in particular) after a write operation completes on it. Without volatile, readers could see some non-updated value.
//synchronized becomes a synchronized block, allowing only one thread to execute at any given time.


//public final class Singleton {
//	//Pole musi zostać zadeklarowane jako volatile, aby mechanizm double check locking działał poprawnie.
//	private static volatile Singleton instance;
//	
//	public String value;
//	
//	//Konstruktor singletona powinien zawsze być zadeklarowany jako prywatrny, aby uniemożliwić wywoływanie na klasie operatora 'new'.
//	private Singleton(String value) {
//		this.value = value;
//	}
//
//	//Statyczna metoda kontrolująca dostęp do instancji singletona. Jest to odroczona inicjalizacja obiektu, ponieważ opóźnia tworzenie obiektu do momentu, gdy jest on rzeczywiście potrzebny.
//	public static Singleton getInstance(String value) {
//		//Stosujemy mechanizm DCL, aby zapobiec wyścigowi między wieloma wątkami, które mogą próbować uzyskać instancję singleton w tym samym czasie, tworząc w rezultacie oddzielne instancje.
//		//Może się wydawać, że posiadanie tutaj zmiennej `result` jest całkowicie bezcelowe. Istnieje jednak bardzo ważne zastrzeżenie podczas implementacji podwójnie sprawdzanego blokowania w Javie, które jest rozwiązywane przez wprowadzenie tej zmiennej lokalnej.
//		Singleton result = instance;
//		if (result != null) {	//Jeżeli instancja singletona już istnieje, to zostanie ona zwrócona.
//			return result;
//		}
//		
//		synchronized (Singleton.class) {	//Stosujemy modyfikator synchronized, aby zabezpieczyć się przed innymi wątkami.
//			if (instance == null) {	//Jeżeli instancja singletona jest nullem, to zostanie utworzona i zwrócona.
//				instance = new Singleton(value);
//			}
//			return instance;
//		}
//	}
//}




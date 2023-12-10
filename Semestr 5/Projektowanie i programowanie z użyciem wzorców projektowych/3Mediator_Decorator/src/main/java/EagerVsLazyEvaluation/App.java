package EagerVsLazyEvaluation;

// Lazy evaluation
// Znana również jako call-by-need, to technika, w której wyrażenie jest obliczane tylko wtedy, 
// gdy jego wartość jest potrzebna. Oznacza to, że obliczenia są odraczane do ostatniego możliwego momentu, 
// a wynik jest buforowany do wykorzystania w przyszłości. Leniwa ewaluacja pozwala uniknąć 
// niepotrzebnej pracy, oszczędza pamięć i umożliwia tworzenie nieskończonych struktur danych. 
// Może jednak również komplikować debugowanie i nieprzewidywalnie wpływać na wydajność. 
// Niektóre języki programowania obsługujące leniwą ewaluację to Haskell, Scala, Clojure i Python.

// Eager evalutaion
// Znana również jako call-by-value, to technika, w której wyrażenie jest obliczane, 
// gdy tylko zostanie powiązane ze zmienną lub przekazane jako argument. Oznacza to, 
// że obliczenia są wykonywane z góry, a wynik jest przechowywany w pamięci. 
// Ewaluacja może uprościć rozumowanie, poprawić wydajność i ułatwić równoległość. 
// Może jednak również marnować zasoby, powodować efekty uboczne i ograniczać ekspresywność. 
// Niektóre języki programowania wykorzystujące ewaluację to C, Java, Ruby i JavaScript.



// version 2.0

public class App {
	public static void main(String[] args) {
		// Eagerly evaluated
		int eagerlyEvaluated = 3 + 4;
		System.out.println("Eagerly evaluated: " + eagerlyEvaluated);
		System.out.println();

        // Lazily evaluated
        LazyEvaluator lazilyEvaluated = new LazyEvaluator(() -> 3 + 4);
        System.out.println("Lazily evaluated: " + lazilyEvaluated.eval());
        System.out.println();
        
        // Ponowne użycie
        System.out.println("Lazily evaluated (again): " + lazilyEvaluated.eval());
	}
	

}

























// version 1.0
//
//public class App {
//	public static void main(String[] args) {
//		String queryString = "password=test";
//	      System.out.println(checkInEagerWay(hasName(queryString)
//	    		  , hasPassword(queryString)));
//	      System.out.println(checkInLazyWay(() -> hasName(queryString)
//	    		  , () -> hasPassword(queryString)));
//
//	}
//
//
//	private static boolean hasName(String queryString) {
//		System.out.println("Checking name: ");
//		return queryString.contains("name");
//	}
//
//	private static boolean hasPassword(String queryString) {
//		System.out.println("Checking password: ");
//		return queryString.contains("password");
//	}
//
//	private static String checkInEagerWay(boolean result1, boolean result2) {
//		return (result1 && result2) ? "all conditions passed" : "failed.";
//	}
//	
//	private static String checkInLazyWay(Supplier<Boolean> result1, Supplier<Boolean> result2) {
//		return (result1.get() && result2.get()) ? "all conditions passed" : "failed.";
//	}
//}









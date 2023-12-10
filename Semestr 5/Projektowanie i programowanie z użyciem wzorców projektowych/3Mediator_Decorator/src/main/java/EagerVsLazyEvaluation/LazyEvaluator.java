package EagerVsLazyEvaluation;

import java.util.function.Supplier;

public class LazyEvaluator {

	// Supplier<T>
	// <T> - typ wyników dostarczanych przez tego dostawcę
	// Jest to interfejs funkcjonalny i dlatego może być używany jako cel przypisania 
	// dla wyrażenia lambda lub odwołania do metody. Jego funkcjonalną metodą jest get().
	
    private Supplier<Integer> expressionSupplier;
    private Integer value;

    // W wywołaniu konstruktora zostanie podana w parametrze nasza funkcja lambda
    public LazyEvaluator(Supplier<Integer> expressionSupplier) {
        this.expressionSupplier = expressionSupplier;
    }

    public int eval() {
        if (value == null) {
        	System.out.println("Funkcja eval() wykorzystuje expressionSupplier do wygenerowania i przypisania wartosci");
            // Jeśli wartość jeszcze nie została wygenerowana, to generujemy ją i przypisujemy do zmiennej
            value = expressionSupplier.get();
            System.out.println("Funkcja eval() zwalnia expressionSupplier");
            // Zwalniamy obiekt odpowiedzialny za generowanie wartości
            expressionSupplier = null;
        } else {
        	System.out.println("Funkcja eval() nie generuje wartosci, bo odwoluje sie do tej przypisanej poprzednio");
        }
        return value;
    }
}

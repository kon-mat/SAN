package konmat.Mediator;

// Komponent bazowy zapewnia podstawową funkcjonalność przechowywania
// instancji mediatora wewnątrz obiektów komponentów.
public class BaseComponent {
	protected Mediator mediator;
	
	public BaseComponent(Mediator mediator) {
		this.mediator = mediator;
	}
	
	public void SetMediator(Mediator mediator) {
		this.mediator = mediator;
	}
}

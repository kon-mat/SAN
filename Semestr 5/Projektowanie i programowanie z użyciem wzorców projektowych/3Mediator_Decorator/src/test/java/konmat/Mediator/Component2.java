package konmat.Mediator;

//Konkretne komponenty implementują różne funkcje. Nie zależą one od innych komponentów. Nie zależą również od żadnego konkretnego mediatora klasy.
public class Component2 extends BaseComponent {
	//Słowo kluczowe "super" umożliwia odwoływanie się do klasy nadrzędnej lub nadklasy podklasy w Javie.
	public Component2(Mediator mediator) {
		super(mediator);
		// TODO Auto-generated constructor stub
	}

	public void DoC() {
		System.out.println("Component 2 does C.");
		this.mediator.Notify(this, "C");
	}
	
	public void DoD() {
		System.out.println("Component 2 does D.");
		this.mediator.Notify(this, "D");
	}
}

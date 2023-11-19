package konmat.Mediator;

//Konkretne komponenty implementują różne funkcje. Nie zależą one od innych komponentów. Nie zależą również od żadnego konkretnego mediatora klasy.
public class Component1 extends BaseComponent {
	//Słowo kluczowe "super" umożliwia odwoływanie się do klasy nadrzędnej lub nadklasy podklasy w Javie.
	public Component1(Mediator mediator) {
		super(mediator);
		// TODO Auto-generated constructor stub
	}

	public void DoA() {
		System.out.println("Component 1 does A.");
		this.mediator.Notify(this, "A");
	}
	
	public void DoB() {
		System.out.println("Component 1 does B.");
		this.mediator.Notify(this, "B");
	}
}

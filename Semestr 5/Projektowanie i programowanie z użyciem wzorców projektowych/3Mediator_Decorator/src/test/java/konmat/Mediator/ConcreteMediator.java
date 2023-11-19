package konmat.Mediator;

import java.util.Objects;

//Konkretne mediatory implementują zachowanie kooperacyjne poprzez koordynację kilku komponentów.
public class ConcreteMediator implements Mediator {
	private Component1 component1;
	private Component2 component2;

	public ConcreteMediator(Component1 component1, Component2 component2) {
		this.component1 = component1;
		this.component1.SetMediator(this);
		this.component2 = component2;
		this.component2.SetMediator(this);
	}
	
	@Override
	public void Notify(Object sender, String event) {
		if (Objects.equals(event, "A")) {
			System.out.println("Mediator reacts on A and triggers the following operations:");
			this.component2.DoC();
		}
		if (Objects.equals(event, "D")) {
			System.out.println("Mediator reacts on D and triggers the following operations:");
			this.component1.DoB();
			this.component2.DoC();
		}

	}

}

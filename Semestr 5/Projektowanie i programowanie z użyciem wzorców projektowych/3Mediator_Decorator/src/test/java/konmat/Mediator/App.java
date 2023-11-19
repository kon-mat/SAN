package konmat.Mediator;

public class App {
	public static void main(String[] args) {
		Component1 component1 = new Component1(null);
		Component2 component2 = new Component2(null);
		Mediator mediator = new ConcreteMediator(component1, component2);
		
		component1.SetMediator(mediator);
		component2.SetMediator(mediator);
		
		System.out.println("Client triggers operation A.");
		component1.DoA();
		
		System.out.println();
		
		System.out.println("Client triggers operation D.");
		component2.DoD();
		
	}
}

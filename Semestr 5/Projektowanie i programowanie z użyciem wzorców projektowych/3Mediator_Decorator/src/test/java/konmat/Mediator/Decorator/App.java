package konmat.Mediator.Decorator;

public class App {
	public static void main(String[] args) {
		Client client = new Client();
		
		ConcreteComponent simple = new ConcreteComponent();
		System.out.println("Client: I get a simple component:");
		client.ClientCode(simple);
		System.out.println();
		
		ConcreteDecoratorA decorator1 = new ConcreteDecoratorA(simple);
		ConcreteDecoratorB decorator2 = new ConcreteDecoratorB(decorator1);
		System.out.println("Client: Now I've got a decorated component:");
		client.ClientCode(decorator2);
	}
}

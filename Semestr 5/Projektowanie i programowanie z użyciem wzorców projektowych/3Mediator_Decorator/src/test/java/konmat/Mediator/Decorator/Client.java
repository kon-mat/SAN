package konmat.Mediator.Decorator;

public class Client {
	public void ClientCode(Component component) {
		System.out.println("RESULT: " + component.Operation());
	}
}

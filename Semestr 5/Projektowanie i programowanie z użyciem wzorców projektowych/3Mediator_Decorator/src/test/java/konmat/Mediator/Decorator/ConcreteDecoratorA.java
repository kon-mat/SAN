package konmat.Mediator.Decorator;

public class ConcreteDecoratorA extends Decorator {

	public ConcreteDecoratorA(Component comp) {
		super(comp);
	}
	
	@Override
	public String Operation() {
		return "ConcreteDecoratorA(" + super.Operation() + ")";
	}

}

package konmat.Mediator.Decorator;

public class ConcreteDecoratorB extends Decorator {

	public ConcreteDecoratorB(Component comp) {
		super(comp);
	}
	
	@Override
	public String Operation() {
		return "ConcreteDecoratorB(" + super.Operation() + ")";
	}

}

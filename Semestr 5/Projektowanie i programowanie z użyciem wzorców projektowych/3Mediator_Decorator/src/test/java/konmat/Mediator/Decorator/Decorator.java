package konmat.Mediator.Decorator;

public abstract class Decorator extends ConcreteComponent {
	protected Component component;
	
	public Decorator(Component component) {
		this.component = component;
	}
	
	public void SetComponent(Component component) {
		this.component = component;
	}
	
	@Override
	public String Operation() {
		if (this.component != null) {
			return this.component.Operation();
		} else {
			return "";
		}
	}
}

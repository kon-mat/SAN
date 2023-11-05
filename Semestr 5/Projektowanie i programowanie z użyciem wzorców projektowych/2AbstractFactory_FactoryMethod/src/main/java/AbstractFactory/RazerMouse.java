package AbstractFactory;

public class RazerMouse implements Mouse {

	@Override
	public void Click() {
		System.out.println("Razer mouse click...");

	}

	@Override
	public void Scroll() {
		System.out.println("Razer mouse scroll...");

	}

}

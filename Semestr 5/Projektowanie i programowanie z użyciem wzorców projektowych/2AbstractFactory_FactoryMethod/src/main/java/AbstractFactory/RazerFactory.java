package AbstractFactory;

public class RazerFactory implements GamingAccessoriesFactory {

	@Override
	public Mouse CreateMouse() {
		return new RazerMouse();
	}

	@Override
	public Keyboard CreateKeyboard() {
		return new RazerKeyboard();
	}

	@Override
	public Headphones CreateHeadphones() {
		return new RazerHeadphones();
	}

}

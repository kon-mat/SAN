package AbstractFactory;

public class SteelSeriesFactory implements GamingAccessoriesFactory {

	@Override
	public Mouse CreateMouse() {
		return new SteelSeriesMouse();
	}

	@Override
	public Keyboard CreateKeyboard() {
		return new SteelSeriesKeyboard();
	}

	@Override
	public Headphones CreateHeadphones() {
		return new SteelSeriesHeadphones();
	}

}

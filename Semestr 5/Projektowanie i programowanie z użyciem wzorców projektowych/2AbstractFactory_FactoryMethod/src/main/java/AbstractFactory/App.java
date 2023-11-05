package AbstractFactory;

public class App {
	private Mouse _mouse;
	private Keyboard _keyboard;
	private Headphones _headphones;
	
	public App(GamingAccessoriesFactory factory) {
		_mouse = factory.CreateMouse();
		_keyboard = factory.CreateKeyboard();
		_headphones = factory.CreateHeadphones();
	}
	
	public void UseHardware() {
		_mouse.Click();
		_mouse.Scroll();
		_keyboard.PressButton();
		_headphones.PlaySound();
	}
}

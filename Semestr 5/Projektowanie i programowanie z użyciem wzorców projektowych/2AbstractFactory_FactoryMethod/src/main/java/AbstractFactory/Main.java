package AbstractFactory;

public class Main {
	private static App ConfigureApp(String brandName) {
		App app;
		GamingAccessoriesFactory factory;
		brandName = brandName.toLowerCase();
		if (brandName.contains("razer")) {
			factory = new RazerFactory();
		} else {
			factory = new SteelSeriesFactory();
		}
		app = new App(factory);
		return app;
	}
	
	public static void main(String[] args) {
		App app = ConfigureApp("razer");
		app.UseHardware();
	}
}

package FactoryMethod;

//Creator
public class OrderLifecycle {
	public void ProcessOrder(String mealName) {
		Meal meal = PrepareMeal(mealName);
		CateringService cateringService = cateringService();
		cateringService.ServeMeal(meal);
	}
	
	protected CateringService cateringService() {
		return new TurkishRestaurant();
	}
	
	private Meal PrepareMeal(String mealName) {
		Meal meal = new Meal(mealName);
		System.out.println(meal + " was prepared.");
		return meal;
	}
	
	public static void main(String[] args) {
		PizzeriaOrderLifecycle pizzeriaOrderLifecycle = new PizzeriaOrderLifecycle();
		OrderLifecycle turkishRestaurantOrderLifecycle = new OrderLifecycle();
		
		turkishRestaurantOrderLifecycle.ProcessOrder("Kebab");
		pizzeriaOrderLifecycle.ProcessOrder("Pizza");
	}
}



//Klasa dodana w przyszlosci na podstawie pierwszej klasy OrderLifecycle (Creator)
class PizzeriaOrderLifecycle extends OrderLifecycle {
	@Override
	protected CateringService cateringService() {
		return new Pizzeria();
	}
}



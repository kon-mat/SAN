package FactoryMethod;

public class Pizzeria implements CateringService {

	@Override
	public void ServeMeal(Meal meal) {
		System.out.println("Pizzeria serve " + meal + ".");
	}
	
}

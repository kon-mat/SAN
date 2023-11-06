package FactoryMethod;

public class TurkishRestaurant implements CateringService {

	@Override
	public void ServeMeal(Meal meal) {
		System.out.println("Turkich Reastaurant serve " + meal + ".");
	}

}

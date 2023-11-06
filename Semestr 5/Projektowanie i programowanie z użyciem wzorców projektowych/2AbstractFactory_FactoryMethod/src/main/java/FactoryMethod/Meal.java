package FactoryMethod;

public class Meal {
	private String _name;
	
	public Meal(String name) {
		_name = name;
	}
	
    @Override
    public String toString() {
        return _name;
    }
}

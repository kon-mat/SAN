package konmat;

//import java.math.BigDecimal;
//import java.math.RoundingMode;
//import java.text.DecimalFormat;
//import java.util.Scanner;

public class App {
	public static void main(String[] args) {

	}
	
	
	public static String HelloMethod() {
		return "Hello";
	}
}	









//Zadanie 1 - tekst
//Scanner scanner = new Scanner(System.in);
//
//System.out.println("Jak masz na imie?");
//String name = scanner.nextLine();
//
//System.out.println("Jak masz na nazwisko?");
//String lastName = scanner.nextLine();
//
//System.out.println("Ile masz lat?");
//int age = scanner.nextInt();
//
//scanner.close();
//
//System.out.println();
//System.out.println("Imie: " + name);
//System.out.println("Nazwisko: " + lastName);
//System.out.println("Wiek: " + age);




//Zadanie 2 - operacje na liczbach
//Scanner scanner = new Scanner(System.in);
//
//System.out.println("Podaj pierwsza liczbe calkowita:");
//double a = scanner.nextInt();
//
//System.out.println("Podaj druga liczbe calkowita:");
//double b = scanner.nextInt();
//
//scanner.close();
//
//System.out.println("Wynik dodawania to " + (a+b));
//System.out.println("Wynik odejmowania to " + (a-b));
//System.out.println("Wynik mnozenia to " + (a*b));
//System.out.println("Wynik dzielenia to " + (a/b));



//Zadanie 3 - zaokraglanie do x miejsc po przecinku
//double a = 2.0;
//double b = 1.5;
//
//double c = a / b;
//
//System.out.println(Math.round(c*100.0)/100.0);	//sztuczka do zaokraglenia x miejsc po przecinku
//
////BigDecimal jest lepszym typem do reprezentowania waluty, niz double
//BigDecimal roundedNumber = new BigDecimal(c).setScale(2, RoundingMode.HALF_UP);
//System.out.println(roundedNumber.doubleValue());
//
////w tym przypadku otrzymujemy , zamiast .
//DecimalFormat decimalFormat = new DecimalFormat("###.##");
//System.out.println(decimalFormat.format(c));
//
////w tym przypadku otrzymujemy , zamiast .
//String formattedNumber = String.format("%.2f", c);
//System.out.println(formattedNumber);



//Zadanie 4 - operacje na tekscie
//String text = "Jak zmienic space na myslnik      ";
//
//// zamiana znakow w tekscie
//String text2 = text.replace(" ", "-");
//
//// usuniecie bialych znakow na poczatku i koncu
//String text3 = text.strip();
//
//// case sensitive
//boolean startsWithJ = text.startsWith("J");
//
//System.out.println(text2);
//System.out.println(text3);
//System.out.println(startsWithJ);





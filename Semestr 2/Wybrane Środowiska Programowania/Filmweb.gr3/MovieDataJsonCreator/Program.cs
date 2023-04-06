using MovieDataJsonCreator;

var source = "D:\\SAN Studia\\Semestr III\\Technologie internetowe\\Lab\\baza_filmow.txt";
var dest = "D:\\SAN Studia\\Semestr III\\Technologie internetowe\\Lab\\baza_filmow.json";
var parser = new FileParser(source);
var movies = parser.GetMovies();
var writer = new FileWriter(dest, movies);
writer.SaveFile();

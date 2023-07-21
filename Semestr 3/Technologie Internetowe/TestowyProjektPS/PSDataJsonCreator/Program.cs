using PSDataJsonCreator;



var source = "D:\\Programowanie\\SAN\\Semestr 3\\Technologie Internetowe\\TestowyProjektPS\\PSDataJsonCreator\\PSDB.txt";
var dest = "D:\\Programowanie\\SAN\\Semestr 3\\Technologie Internetowe\\TestowyProjektPS\\PSDataJsonCreator\\PSDataBase.json";
var parser = new FileParser(source);
var movies = parser.GetProblemSolvers();
var writer = new FileWriter(dest, movies);
writer.SaveFile();
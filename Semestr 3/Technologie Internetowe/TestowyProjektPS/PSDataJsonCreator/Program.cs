using PSDataJsonCreator;



var source = "D:\\Programowanie\\Programiki\\Visual Studio 2019\\source\\repos\\TestowyProjektPS\\PSDataJsonCreator\\PSDB.txt";
var dest = "D:\\Programowanie\\Programiki\\Visual Studio 2019\\source\\repos\\TestowyProjektPS\\PSDataJsonCreator\\PSDataBase.json";
var parser = new FileParser(source);
var movies = parser.GetProblemSolvers();
var writer = new FileWriter(dest, movies);
writer.SaveFile();
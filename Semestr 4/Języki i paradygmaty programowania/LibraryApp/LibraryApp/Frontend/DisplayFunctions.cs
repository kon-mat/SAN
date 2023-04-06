using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using LibraryLogic.Components;
using LibraryLogic.Objects;
using LibraryLogic.Responses;
using static System.Reflection.Metadata.BlobBuilder;

namespace LibraryApp.Frontend
{
    internal class DisplayFunctions
    {
        private Library _library;

        public DisplayFunctions()
        {
            _library = new Library();
        }


        public void DisplayLoginWindow()
        {
            int i = 1;
            Console.WriteLine("Wybierz użytkownika:");
            Console.WriteLine($"{i}. Bibliotekarz");
            foreach (User user in _library.GetUsers())
                Console.WriteLine($"{user.Id + 1}. Użytkownik {user.Name}");
            Console.WriteLine();
            Console.WriteLine($"Twój wybór: ");
        }

        public void DisplayLibrarianMainMenu()
        {
            Console.WriteLine("Wybierz opcje:");
            Console.WriteLine("1. Wyszukiwanie");
            Console.WriteLine("2. Spis książek i użytkowników");
            Console.WriteLine("3. Edycja spisu");
            Console.WriteLine("4. Wyloguj");
            Console.WriteLine();
            Console.WriteLine($"Twój wybór: ");
        }

        public void DisplayLibrarianSearchMenu()
        {
            Console.WriteLine("Wybierz opcje:");
            Console.WriteLine("1. Wyszukiwanie na podstawie tytułu");
            Console.WriteLine("2. Wyszukiwanie na podstawie autora");
            Console.WriteLine("3. Wyszukiwanie na podstawie gatunku");
            Console.WriteLine("4. Powrót do menu");
            Console.WriteLine();
            Console.WriteLine($"Twój wybór: ");
        }

        public void DisplayLibrarianBooksListMenu()
        {
            Console.WriteLine("Wybierz opcje:");
            Console.WriteLine("1. Wyświetl wszystkie książki");
            Console.WriteLine("2. Wyświetl wszystkie dostępne książki");
            Console.WriteLine("3. Wyświetl wszystkie wypożyczone książki");
            Console.WriteLine("4. Wyświetl wszystkich czytelników");
            Console.WriteLine("5. Wyświetl archiwum wypożyczeń");
            Console.WriteLine("6. Powrót do menu");
            Console.WriteLine();
            Console.WriteLine($"Twój wybór: ");
        }

        public void DisplayLibrarianEditionMenu()
        {
            Console.WriteLine("Wybierz opcje:");
            Console.WriteLine("1. Dodaj nową książkę do spisu");
            Console.WriteLine("2. Usuń książkę ze spisu");
            Console.WriteLine("3. Zaktualizuj informacje o książce");
            Console.WriteLine("4. Powrót do menu");
            Console.WriteLine();
            Console.WriteLine($"Twój wybór: ");
        }

        public void DisplayLibrarianUpdateBookMenu()
        {
            Console.WriteLine("Wybierz, którą wartość chcesz edytować:");
            Console.WriteLine("1. Tytuł");
            Console.WriteLine("2. Autor");
            Console.WriteLine("3. Rok wydania");
            Console.WriteLine("4. ISBN");
            Console.WriteLine("5. Gatunek");
            Console.WriteLine();
            Console.WriteLine($"Twój wybór: ");
        }

        public void DisplayReaderMainMenu()
        {
            Console.WriteLine("Wybierz opcje:");
            Console.WriteLine("1. Wyszukiwanie");
            Console.WriteLine("2. Obsluga konta");
            Console.WriteLine("3. Wyloguj");
            Console.WriteLine();
            Console.WriteLine($"Twoj wybor: ");
        }

        public void DisplayReaderSearchMenu()
        {
            Console.WriteLine("Wybierz opcje:");
            Console.WriteLine("1. Wyszukiwanie na podstawie tytułu");
            Console.WriteLine("2. Wyszukiwanie na podstawie autora");
            Console.WriteLine("3. Wyszukiwanie na podstawie gatunku");
            Console.WriteLine("4. Wyświetl wszystkie dostępne książki");
            Console.WriteLine("5. Powrót do menu");
            Console.WriteLine();
            Console.WriteLine($"Twój wybór: ");
        }

        public void DisplayReaderServiceMenu()
        {
            Console.WriteLine("Wybierz opcje:");
            Console.WriteLine("1. Wyświetl aktualnie wypożyczone książki");
            Console.WriteLine("2. Wyświetl historię wypożyczeń");
            Console.WriteLine("3. Wypożycz książkę");
            Console.WriteLine("4. Zwróć książkę");
            Console.WriteLine("5. Powrót do menu");
            Console.WriteLine();
            Console.WriteLine($"Twój wybór: ");
        }

        public void DisplaySearchedBooks(List<SimpleBook> searchedBooks, string searchOption)
        {
            int index = 0;
            Console.WriteLine($"Lista wyszukanych ksiazek na podstawie slowa kluczowego {searchOption}:");
            foreach (SimpleBook book in searchedBooks)
                Console.WriteLine($"{++index}. {book.Title}, {book.Author}, {book.Genre} - Numer referencyjny: {book.Id}");
        }

        public void DisplayBooks(List<SimpleBook> books)
        {
            int index = 0;
            foreach (SimpleBook book in books)
                Console.WriteLine($"{++index}. {book.Title}, {book.Author}, {book.Genre} - Numer referencyjny: {book.Id}");
        }

        public void DisplayBooksDetails(Book book)
        {
            if (book == null)
                Console.Write("Książka o podanym numerze referencyjnym nie znajduje się w spisie.");
            else
            {
                Console.WriteLine($"Id: {book.Id}");
                Console.WriteLine($"Tytuł: {book.Title}");
                Console.WriteLine($"Autor: {book.Author}");
                Console.WriteLine($"Rok wydania: {book.YearOfPublication}");
                Console.WriteLine($"ISBN: {book.Isbn}");
                Console.WriteLine($"Gatunek: {book.Genre}");
                Console.WriteLine(book.Avaible == true ? "Dostępna" : "Wypożyczona");
            }
        }

        public void DisplayBorrowedBooks(List<Book> books)
        {
            if (books != null)
            {
                int index = 0;
                foreach (Book book in books)
                    Console.WriteLine($"{++index}. {book.Title} - wypożyczona przez {book.Borrower.Name} {book.Borrower.Surname}");
            }
        }

        public void DisplayUsersBorrowedBooks(List<Book> books)
        {
            int index = 0;
            foreach (Book book in books)
            {
                Console.WriteLine($"{++index}. {book.Title} - Numer referencyjny: {book.Id}");
                Console.WriteLine($"Książkę wypożyczono: {book.BorrowDate}");
                Console.WriteLine($"Ostateczny termin zwrotu: {book.ReturnDate}");
                Console.WriteLine();
            }
        }

        public void DisplayUsers(List<User> users)
        {
            int index = 0;
            foreach (User user in users)
                Console.WriteLine($"{++index}. {user.Name} {user.Surname}, wypożyczone książki: {user.BorrowedBooks.Count}");
        }

        public bool DisplayNewBooksDetails(List<dynamic> newBooksDetails)
        {
            Console.Clear();
            if (newBooksDetails.Count != 5)
            {
                Console.WriteLine("Nieprawidłowa ilość informacji na temat nowej książki.");
                return false;
            }

            Console.WriteLine("Informacje na temat nowej książki:");
            Console.WriteLine($"Tytuł: {newBooksDetails[0]}");
            Console.WriteLine($"Autor: {newBooksDetails[1]}");
            Console.WriteLine($"Rok wydania: {newBooksDetails[2]}");
            Console.WriteLine($"ISBN: {newBooksDetails[3]}");
            Console.WriteLine($"Gatunek: {newBooksDetails[4]}");
            Console.WriteLine();
            Console.WriteLine("Wpisz \"1\", jeżeli potwierdzasz, że wszystkie powyższe informacje są prawidłowe.");
            string usersSelection = Console.ReadLine();

            return usersSelection == "1" ? true : false;
        }

        public void DisplayRentalsArchive(List<ArchivedRental> archivedRentals)
        {
            Console.WriteLine("Archiwum wypożyczonych książek:");
            Console.WriteLine();
            foreach (ArchivedRental rental in archivedRentals)
            {
                Console.WriteLine($"Tytuł: {_library.GetBookById(rental.BookId).Title}");
                Console.WriteLine($"Osoba wypożyczająca: {rental.Borrower.Name} {rental.Borrower.Surname}");
                Console.WriteLine($"Data wypożyczenia książki: {rental.BorrowDate}");
                Console.WriteLine($"Data zwrotu książki: {rental.ReturnDate}");
                Console.WriteLine();
            }
        }

        public void DisplayReadersRentalsArchive(List<ArchivedRental> archivedRentals)
        {
            Console.WriteLine("Twoja historia wypożyczeń:");
            Console.WriteLine();
            foreach (ArchivedRental rental in archivedRentals)
            {
                Console.WriteLine($"Tytuł: {_library.GetBookById(rental.BookId).Title}");
                Console.WriteLine($"Data wypożyczenia książki: {rental.BorrowDate}");
                Console.WriteLine($"Data zwrotu książki: {rental.ReturnDate}");
                Console.WriteLine();
            }
        }




        /*   
        Plan programu
        1. Wybieramy uzytkownika systemu (Bibliotekarz, Czytelnik1, Czytelnik2 ....)
        
        a) Bibliotekarz
            1. Wyszukiwanie
                1. Wyszukaj na podstawie tytulu
                2. Wyszukaj na podstawie autora
                3. Wyszukaj na podstawie gatunku
                4. Powrót
            2. Spis książek i uzytkownikow
                1. Wyświetl wszystkie książki
                2. Wyświetl wszystkie dostępne książki
                3. Wyświetl wszystkie wypożyczone książki oraz nazwisko i imie wyp.
                4. Wyświetl wszystkich czytelnikow
                5. Wyswietl archiwum wypozyczen
                5. Powrót
            3. Edycja spisu
                1. Dodaj nową książkę do spisu
                2. Usuń książkę ze spisu
                3. Zaktualizuj informacje o książce
                5. Powrót
            4. Wyjscie
        
        b) Czytelnik
            1. Wyszukiwanie
                1. Wyszukaj na podstawie tytulu
                2. Wyszukaj na podstawie autora
                3. Wyszukaj na podstawie gatunku
                4. Wyświetl wszystkie dostępne książki
                5. Powrót
            2. Obsluga czytelnika
                1. Wyswietl aktualnie wypozyczone ksiazki
                2. Wyswietl historie wypozyczen
                3. Wypozyc ksiazke
                4. Zwroc ksiazke
                5. Powrót
            3. Wyjscie
         */

    }
}

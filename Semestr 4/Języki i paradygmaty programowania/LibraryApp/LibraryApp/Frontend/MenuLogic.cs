using LibraryLogic.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Frontend
{
    internal class MenuLogic
    {
        private Library _library;
        private bool? _librarian;
        private User? _currentUser;
        private DisplayFunctions _display; 

        public MenuLogic()
        {
            _library = new Library();
            _display = new DisplayFunctions();
        }


        //  ---[ INPUTS ]---

        public void UserSelection()
        {
            _display.DisplayLoginWindow();
            string usersSelection = Console.ReadLine();
            int selectedNumber;

            while (!int.TryParse(usersSelection, out selectedNumber) || selectedNumber != 1 && !_library.GetUsers().Select(user => user.Id).Contains(selectedNumber - 1))
            {
                Console.Clear();
                Console.WriteLine($"{usersSelection} nie jest poprawnym wyborem, sprobuj ponownie.");
                Console.WriteLine();
                _display.DisplayLoginWindow();
                usersSelection = Console.ReadLine();
            }
            Console.Clear();

            _librarian = selectedNumber == 1 ? true : false;
            _currentUser = _librarian == true ? null : _library.GetUsers().FirstOrDefault(user => user.Id == selectedNumber - 1);
            if (_librarian == true)
                LibrarianMenuSelection();
            else
                ReaderMenuSelection();

        }

        public void LibrarianMenuSelection()
        {
            _display.DisplayLibrarianMainMenu();
            string usersSelection = Console.ReadLine();
            int selectedNumber;

            while (!int.TryParse(usersSelection, out selectedNumber) || selectedNumber != 1 && selectedNumber != 2 && selectedNumber != 3 && selectedNumber != 4)
            {
                Console.Clear();
                Console.WriteLine($"{usersSelection} nie jest poprawnym wyborem, sprobuj ponownie.");
                Console.WriteLine();
                _display.DisplayLibrarianMainMenu();
                usersSelection = Console.ReadLine();
            }
            Console.Clear();

            switch (selectedNumber)
            {
                case 1:
                    LibrarianSearch();
                    break;
                case 2:
                    LibrarianBooksList();
                    break;
                case 3:
                    LibrarianListEdition();
                    break;
                case 4:
                    _librarian = false;
                    _currentUser = null;
                    UserSelection();
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("Nieprawidłowy wybór.");
                    Console.WriteLine();
                    LibrarianMenuSelection();
                    break;
            }
        }

        public void ReaderMenuSelection()
        {
            _display.DisplayReaderMainMenu();
            string usersSelection = Console.ReadLine();
            int selectedNumber;

            while (!int.TryParse(usersSelection, out selectedNumber) || selectedNumber != 1 && selectedNumber != 2 && selectedNumber != 3)
            {
                Console.Clear();
                Console.WriteLine($"{usersSelection} nie jest poprawnym wyborem, sprobuj ponownie.");
                Console.WriteLine();
                _display.DisplayReaderMainMenu();
                usersSelection = Console.ReadLine();
            }
            Console.Clear();

            switch (selectedNumber)
            {
                case 1:
                    ReaderSearch();
                    break;
                case 2:
                    ReaderService();
                    break;
                case 3:
                    _librarian = false;
                    _currentUser = null;
                    UserSelection();
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("Nieprawidłowy wybór.");
                    Console.WriteLine();
                    ReaderMenuSelection();
                    break;
            }
        }

        public string ReadSearchTerm(string type)
        {
            Console.WriteLine($"Podaj {type} książki:");
            string searchTerm = Console.ReadLine();
            while (string.IsNullOrWhiteSpace(searchTerm) || searchTerm.Length < 2)
            {
                Console.Clear();
                Console.WriteLine($"Niestety, ale {searchTerm} to nieprawidlowa wartość.");
                Console.WriteLine("Wyszukiwane słowo nie może być puste i musi składać się z przynajmniej 2 znaków.");
                Console.WriteLine();
                Console.WriteLine($"Podaj {type} książki:");
                searchTerm = Console.ReadLine();
            }

            return searchTerm;
        }

        public string ReadTitleAuthorGenre(string type)
        {
            Console.Clear();
            Console.WriteLine($"Podaj {type} książki:");
            string newBookTerm = Console.ReadLine();
            while (string.IsNullOrWhiteSpace(newBookTerm) || newBookTerm.Length < 2)
            {
                Console.Clear();
                Console.WriteLine($"Niestety, ale {newBookTerm} to nieprawidłowa wartość.");
                Console.WriteLine("Podane słowo nie może być puste i musi składać się z przynajmniej 2 znaków.");
                Console.WriteLine();
                Console.WriteLine($"Podaj {type} książki:");
                newBookTerm = Console.ReadLine();
            }

            return newBookTerm;
        }

        public int ReadYearOfPublication()
        {
            Console.Clear();
            Console.WriteLine($"Podaj rok publikacji książki:");
            string year = Console.ReadLine();
            int yearOfPublication;
            while (!int.TryParse(year, out yearOfPublication) || yearOfPublication > DateTime.UtcNow.Year)
            {
                Console.Clear();
                Console.WriteLine($"Niestety, ale {year} to nieprawidłowa wartość.");
                Console.WriteLine("Podany rok nie może być większy, niż aktualny rok.");
                Console.WriteLine();
                Console.WriteLine($"Podaj rok publikacji książki:");
                year = Console.ReadLine();
            }

            return yearOfPublication;
        }

        public string ReadIsbn()
        {
            Console.Clear();
            Console.WriteLine($"Podaj isbn książki:");
            string isbn = Console.ReadLine();
            while (string.IsNullOrWhiteSpace(isbn) || isbn.Length != 13)
            {
                Console.Clear();
                Console.WriteLine($"Niestety, ale {isbn} to nieprawidłowa wartość.");
                Console.WriteLine("Podane słowo nie może być puste i musi składać się z 13 znaków.");
                Console.WriteLine();
                Console.WriteLine($"Podaj isbn książki:");
                isbn = Console.ReadLine();
            }

            return isbn;
        }

        public List<dynamic> ReadNewBooksDetails()
        {
            List<dynamic> booksDetails = new List<dynamic>();
            string title = ReadTitleAuthorGenre("tytuł");
            string author = ReadTitleAuthorGenre("autora");
            int yearOfPublication = ReadYearOfPublication();
            string isbn = ReadIsbn();
            string genre = ReadTitleAuthorGenre("gatunek");
            booksDetails.Add(title);
            booksDetails.Add(author);
            booksDetails.Add(yearOfPublication);
            booksDetails.Add(isbn);
            booksDetails.Add(genre);

            return booksDetails;
        }

        public int ReadBookId()
        {
            Console.WriteLine("Podaj numer referencyjny książki, którą chcesz wybrać:");
            string usersSelection = Console.ReadLine();
            int selectedNumber;

            while (!int.TryParse(usersSelection, out selectedNumber) || !_library.GetAllBooks().Select(book => book.Id).Contains(selectedNumber))
            {
                Console.Clear();
                Console.WriteLine($"{usersSelection} nie jest poprawnym wyborem, sprobuj ponownie.");
                Console.WriteLine();
                Console.WriteLine("Podaj numer referencyjny książki, którą chcesz wybrać:");
                usersSelection = Console.ReadLine();
            }
            Console.Clear();

            return selectedNumber;
        }

        public int ReadUpdateType(int bookId)
        {
            _display.DisplayBooksDetails(_library.GetBookById(bookId));
            Console.WriteLine(); //
            _display.DisplayLibrarianUpdateBookMenu();
            string usersSelection = Console.ReadLine();
            int selectedNumber;

            while (!int.TryParse(usersSelection, out selectedNumber) || (selectedNumber != 1 && selectedNumber != 2 && selectedNumber != 3 && selectedNumber != 4 && selectedNumber != 5))
            {
                Console.Clear();
                Console.WriteLine($"{usersSelection} nie jest poprawnym wyborem, sprobuj ponownie.");
                Console.WriteLine();
                _display.DisplayBooksDetails(_library.GetBookById(bookId));
                Console.WriteLine(); //
                _display.DisplayLibrarianUpdateBookMenu();
                usersSelection = Console.ReadLine();
            }
            Console.Clear();

            return selectedNumber;

        }








        //  ---[ LIBRARIAN FUNCTIONS ]---

        public void LibrarianSearch()
        {
            _display.DisplayLibrarianSearchMenu();
            string usersSelection = Console.ReadLine();
            int selectedNumber;

            while (!int.TryParse(usersSelection, out selectedNumber) || selectedNumber != 1 && selectedNumber != 2 && selectedNumber != 3 && selectedNumber != 4)
            {
                Console.Clear();
                Console.WriteLine();
                Console.WriteLine($"{usersSelection} nie jest poprawnym wyborem, sprobuj ponownie.");
                Console.WriteLine();
                _display.DisplayLibrarianSearchMenu();
                usersSelection = Console.ReadLine();
            }
            Console.Clear();

            switch (selectedNumber)
            {
                case 1:
                    string title = ReadSearchTerm("tytułu");
                    Console.Clear();
                    Console.WriteLine("Wyszukiwanie na podstawie tytułu");
                    Console.WriteLine();
                    _display.DisplaySearchedBooks(_library.SearchByTitle(title).ToList(), title);
                    Console.WriteLine();
                    Console.WriteLine("Naciśnij dowolny klawisz, aby wrócić do głównego menu.");
                    Console.ReadKey();
                    Console.Clear();
                    LibrarianMenuSelection();
                    break;

                case 2:
                    string author = ReadSearchTerm("autora");
                    Console.Clear();
                    Console.WriteLine("Wyszukiwanie na podstawie autora");
                    Console.WriteLine();
                    _display.DisplaySearchedBooks(_library.SearchByAuthor(author).ToList(), author);
                    Console.WriteLine();
                    Console.WriteLine("Naciśnij dowolny klawisz, aby wrócić do głównego menu.");
                    Console.ReadKey();
                    Console.Clear();
                    LibrarianMenuSelection();
                    break;

                case 3:
                    string genre = ReadSearchTerm("autora");
                    Console.Clear();
                    Console.WriteLine("Wyszukiwanie na podstawie autora");
                    Console.WriteLine();
                    _display.DisplaySearchedBooks(_library.SearchByGenre(genre).ToList(), genre);
                    Console.WriteLine();
                    Console.WriteLine("Naciśnij dowolny klawisz, aby wrócić do głównego menu.");
                    Console.ReadKey();
                    Console.Clear();
                    LibrarianMenuSelection();
                    break;

                case 4:
                    Console.Clear();
                    LibrarianMenuSelection();
                    break;

                default:
                    Console.Clear();
                    Console.WriteLine("Nieprawidłowy wybór.");
                    Console.WriteLine();
                    LibrarianMenuSelection();
                    break;
            }
        }   // LibrarianSearch

        public void LibrarianBooksList()
        {
            _display.DisplayLibrarianBooksListMenu();
            string usersSelection = Console.ReadLine();
            int selectedNumber;

            while (!int.TryParse(usersSelection, out selectedNumber) || selectedNumber != 1 && selectedNumber != 2 && selectedNumber != 3 && selectedNumber != 4 && selectedNumber != 5 && selectedNumber != 6)
            {
                Console.Clear();
                Console.WriteLine();
                Console.WriteLine($"{usersSelection} nie jest poprawnym wyborem, sprobuj ponownie.");
                Console.WriteLine();
                _display.DisplayLibrarianBooksListMenu();
                usersSelection = Console.ReadLine();
            }
            Console.Clear();

            switch (selectedNumber)
            {
                case 1:
                    Console.Clear();
                    Console.WriteLine("Lista wszystkich książek:");
                    _display.DisplayBooks(_library.GetAllBooks().ToList());
                    Console.WriteLine();
                    Console.WriteLine("Naciśnij dowolny klawisz, aby wrócić do głównego menu.");
                    Console.ReadKey();
                    Console.Clear();
                    LibrarianMenuSelection();
                    break;

                case 2:
                    Console.Clear();
                    Console.WriteLine("Lista wszystkich dostępnych książek:");
                    _display.DisplayBooks(_library.GetAvaibleBooks().ToList());
                    Console.WriteLine();
                    Console.WriteLine("Naciśnij dowolny klawisz, aby wrócić do głównego menu.");
                    Console.ReadKey();
                    Console.Clear();
                    LibrarianMenuSelection();
                    break;

                case 3:
                    Console.Clear();
                    Console.WriteLine("Lista wszystkich wypożyczonych książek:");
                    _display.DisplayBorrowedBooks(_library.GetBorrowedBooks().ToList());
                    Console.WriteLine();
                    Console.WriteLine("Naciśnij dowolny klawisz, aby wrócić do głównego menu.");
                    Console.ReadKey();
                    Console.Clear();
                    LibrarianMenuSelection();
                    break;

                case 4:
                    Console.Clear();
                    Console.WriteLine("Lista wszystkich czytelników:");
                    _display.DisplayUsers(_library.GetUsers().ToList());
                    Console.WriteLine();
                    Console.WriteLine("Naciśnij dowolny klawisz, aby wrócić do głównego menu.");
                    Console.ReadKey();
                    Console.Clear();
                    LibrarianMenuSelection();
                    break;

                case 5:
                    Console.Clear();
                    _display.DisplayRentalsArchive(_library.GetRentalArchive().ToList());
                    Console.WriteLine();
                    Console.WriteLine("Naciśnij dowolny klawisz, aby wrócić do głównego menu.");
                    Console.ReadKey();
                    Console.Clear();
                    LibrarianMenuSelection();
                    break;

                case 6:
                    Console.Clear();
                    LibrarianMenuSelection();
                    break;

                default:
                    Console.Clear();
                    Console.WriteLine("Nieprawidłowy wybór.");
                    Console.WriteLine();
                    LibrarianMenuSelection();
                    break;
            }
        }   // LibrarianBooksList

        public void LibrarianListEdition()
        {
            _display.DisplayLibrarianEditionMenu();
            string usersSelection = Console.ReadLine();
            int selectedNumber;

            while (!int.TryParse(usersSelection, out selectedNumber) || selectedNumber != 1 && selectedNumber != 2 && selectedNumber != 3 && selectedNumber != 4)
            {
                Console.Clear();
                Console.WriteLine($"{usersSelection} nie jest poprawnym wyborem, sprobuj ponownie.");
                Console.WriteLine();
                _display.DisplayLibrarianEditionMenu();
                usersSelection = Console.ReadLine();
            }
            Console.Clear();


            switch (selectedNumber)
            {
                case 1:
                    Console.Clear();
                    List<dynamic> booksDetails = ReadNewBooksDetails();
                    bool confirmed = _display.DisplayNewBooksDetails(booksDetails);
                    Console.WriteLine();
                    if (confirmed)
                    {
                        string addResponse = _library.AddBook(booksDetails[0], booksDetails[1], booksDetails[2], booksDetails[3], booksDetails[4]);
                        if (addResponse == "BookAdded")
                            Console.WriteLine("Informacje zostały potwierdzone. Książka została dodana do spisu.");
                        else
                            Console.WriteLine(addResponse);
                    }
                    else
                        Console.WriteLine("Informacje nie zostały potwierdzone jako prawidłowe. Aby dodać książkę do spisu spróbuj wpisać je ponownie.");
                    Console.WriteLine();
                    Console.WriteLine("Naciśnij dowolny klawisz, aby wrócić do głównego menu.");
                    Console.ReadKey();
                    Console.Clear();
                    LibrarianMenuSelection();
                    break;

                case 2:
                    Console.Clear();
                    int bookId = ReadBookId();
                    _display.DisplayBooksDetails(_library.GetBookById(bookId));
                    Console.WriteLine();
                    Console.WriteLine("Wpisz \"1\", jeżeli potwierdzasz, że chcesz usunąć powyższą książkę ze spisu.");
                    string userConfirm = Console.ReadLine();
                    if (userConfirm == "1")
                    {
                        Console.Clear();
                        string removeResponse = _library.RemoveBook(_library.GetBookById(bookId)).ToString();
                        if (removeResponse == "BookRemoved")
                            Console.WriteLine("Książka została usunięta ze spisu");
                        else 
                            Console.WriteLine(removeResponse);
                    }
                    else
                        Console.WriteLine("Usunięcie nie zostało potwierdzone. Aby usunąć książkę ze spisu spróbuj ponownie.");
                    Console.WriteLine();
                    Console.WriteLine("Naciśnij dowolny klawisz, aby wrócić do głównego menu.");
                    Console.ReadKey();
                    Console.Clear();
                    LibrarianMenuSelection();
                    break;

                case 3:
                    Console.Clear();
                    bookId = ReadBookId();
                    int updateType = ReadUpdateType(bookId);
                    Console.WriteLine("Podaj nową wartość:");
                    string newValue = Console.ReadLine();
                    string updateResponse = _library.UpdateBook(_library.GetBookById(bookId), newValue, updateType).ToString();
                    if (updateResponse == "BookUpdated")
                        Console.WriteLine("Wartość została zaktualizowana.");
                    else 
                        Console.WriteLine(updateResponse);
                    Console.WriteLine();
                    Console.WriteLine("Naciśnij dowolny klawisz, aby wrócić do głównego menu.");
                    Console.ReadKey();
                    Console.Clear();
                    LibrarianMenuSelection();
                    break;

                case 4:
                    Console.Clear();
                    LibrarianMenuSelection();
                    break;

                default:
                    Console.Clear();
                    Console.WriteLine("Nieprawidłowy wybór.");
                    Console.WriteLine();
                    LibrarianMenuSelection();
                    break;
            }

        }   // LibrarianListEdition

        public void ReaderSearch()
        {
            _display.DisplayReaderSearchMenu();
            string usersSelection = Console.ReadLine();
            int selectedNumber;

            while (!int.TryParse(usersSelection, out selectedNumber) || selectedNumber != 1 && selectedNumber != 2 && selectedNumber != 3 && selectedNumber != 4 && selectedNumber != 5)
            {
                Console.Clear();
                Console.WriteLine();
                Console.WriteLine($"{usersSelection} nie jest poprawnym wyborem, sprobuj ponownie.");
                Console.WriteLine();
                _display.DisplayReaderSearchMenu();
                usersSelection = Console.ReadLine();
            }
            Console.Clear();

            switch (selectedNumber)
            {
                case 1:
                    string title = ReadSearchTerm("tytułu");
                    Console.Clear();
                    Console.WriteLine("Wyszukiwanie na podstawie tytułu");
                    Console.WriteLine();
                    _display.DisplaySearchedBooks(_library.SearchByTitle(title).ToList(), title);
                    Console.WriteLine();
                    Console.WriteLine("Naciśnij dowolny klawisz, aby wrócić do głównego menu.");
                    Console.ReadKey();
                    Console.Clear();
                    ReaderMenuSelection();
                    break;

                case 2:
                    string author = ReadSearchTerm("autora");
                    Console.Clear();
                    Console.WriteLine("Wyszukiwanie na podstawie autora");
                    Console.WriteLine();
                    _display.DisplaySearchedBooks(_library.SearchByAuthor(author).ToList(), author);
                    Console.WriteLine();
                    Console.WriteLine("Naciśnij dowolny klawisz, aby wrócić do głównego menu.");
                    Console.ReadKey();
                    Console.Clear();
                    ReaderMenuSelection();
                    break;

                case 3:
                    string genre = ReadSearchTerm("autora");
                    Console.Clear();
                    Console.WriteLine("Wyszukiwanie na podstawie autora");
                    Console.WriteLine();
                    _display.DisplaySearchedBooks(_library.SearchByGenre(genre).ToList(), genre);
                    Console.WriteLine();
                    Console.WriteLine("Naciśnij dowolny klawisz, aby wrócić do głównego menu.");
                    Console.ReadKey();
                    Console.Clear();
                    ReaderMenuSelection();
                    break;

                case 4:
                    Console.Clear();
                    Console.WriteLine("Lista wszystkich książek:");
                    _display.DisplayBooks(_library.GetAllBooks().ToList());
                    Console.WriteLine();
                    Console.WriteLine("Naciśnij dowolny klawisz, aby wrócić do głównego menu.");
                    Console.ReadKey();
                    Console.Clear();
                    ReaderMenuSelection();
                    break;

                case 5:
                    Console.Clear();
                    ReaderMenuSelection();
                    break;

                default:
                    Console.Clear();
                    Console.WriteLine("Nieprawidłowy wybór.");
                    Console.WriteLine();
                    ReaderMenuSelection();
                    break;
            }
        }   // ReaderSearch

        public void ReaderService()
        {
            _display.DisplayReaderServiceMenu();
            string usersSelection = Console.ReadLine();
            int selectedNumber;

            while (!int.TryParse(usersSelection, out selectedNumber) || selectedNumber != 1 && selectedNumber != 2 && selectedNumber != 3 && selectedNumber != 4 && selectedNumber != 5)
            {
                Console.Clear();
                Console.WriteLine();
                Console.WriteLine($"{usersSelection} nie jest poprawnym wyborem, sprobuj ponownie.");
                Console.WriteLine();
                _display.DisplayReaderServiceMenu();
                usersSelection = Console.ReadLine();
            }
            Console.Clear();

            switch (selectedNumber)
            {
                case 1:
                    Console.Clear();
                    Console.WriteLine("Twoje wypożyczone książki:");
                    Console.WriteLine();
                    _display.DisplayUsersBorrowedBooks(_library.GetUsersBorrowedBooks(_currentUser).ToList());
                    Console.WriteLine();
                    Console.WriteLine("Naciśnij dowolny klawisz, aby wrócić do głównego menu.");
                    Console.ReadKey();
                    Console.Clear();
                    ReaderMenuSelection();
                    break;

                case 2:
                    Console.Clear();
                    _display.DisplayReadersRentalsArchive(_library.GetRentalArchiveByUser(_currentUser));
                    Console.WriteLine();
                    Console.WriteLine("Naciśnij dowolny klawisz, aby wrócić do głównego menu.");
                    Console.ReadKey();
                    Console.Clear();
                    ReaderMenuSelection();
                    break;

                case 3:
                    Console.Clear();
                    int bookId = ReadBookId();
                    _display.DisplayBooksDetails(_library.GetBookById(bookId));
                    Console.WriteLine();
                    if (_library.GetBookById(bookId).Avaible)
                    {
                        Console.WriteLine("Wpisz \"1\", jeżeli potwierdzasz, że chcesz wypożyczyć powyższą książkę.");
                        string userConfirm = Console.ReadLine();
                        if (userConfirm == "1")
                        {
                            Console.Clear();
                            string borrowResponse = _currentUser.BoorrowBook(_library.GetBookById(bookId), _library).ToString();
                            if (borrowResponse == "BookLentSuccessfully")
                                Console.WriteLine($"Książka została wypożyczona. Ostateczny termin zwrotu: {_library.GetBookById(bookId).ReturnDate}.");
                            else
                                Console.WriteLine(borrowResponse);
                        }
                        else
                            Console.WriteLine("Wypożyczenie nie zostało potwierdzone. Aby wypożyczyć książkę ze spróbuj ponownie.");
                    }
                    else
                        Console.WriteLine("Powyższa książka nie jest aktualnie dostępna do wypożyczenia.");
                    Console.WriteLine();
                    Console.WriteLine("Naciśnij dowolny klawisz, aby wrócić do głównego menu.");
                    Console.ReadKey();
                    Console.Clear();
                    ReaderMenuSelection();
                    break;

                case 4:
                    Console.Clear();
                    bookId = ReadBookId();
                    if (_currentUser.BorrowedBooks.Select(book => book.Id).Contains(bookId))
                    {
                        string returnResponse = _currentUser.ReturnBook(_library.GetBookById(bookId), _library).ToString();
                        if (returnResponse == "BookReceivedSuccessfully")
                            Console.WriteLine("Zwróciłeś wypożyczoną książkę do biblioteki.");
                        else 
                            Console.WriteLine(returnResponse);
                    }
                    else
                        Console.WriteLine($"Książka o numerzece referencyjnym {bookId} nie jest przez Ciebie wypożyczona.");
                    Console.WriteLine();
                    Console.WriteLine("Naciśnij dowolny klawisz, aby wrócić do głównego menu.");
                    Console.ReadKey();
                    Console.Clear();
                    ReaderMenuSelection();
                    break;

                case 5:
                    Console.Clear();
                    ReaderMenuSelection();
                    break;

                default:
                    Console.Clear();
                    Console.WriteLine("Nieprawidłowy wybór.");
                    Console.WriteLine();
                    ReaderMenuSelection();
                    break;
            }


            



        }   // ReaderService






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

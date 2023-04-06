using LibraryLogic.Components;
using LibraryLogic.Interfaces;
using LibraryLogic.Repositories;
using LibraryLogic.Responses;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace LibraryLogic.Objects
{
    public class Library : ILibrary
    {
        private BooksRepository _booksRepository;
        private UsersRepository _usersRepository;
        private ArchiveRepository _archiveRepository;

        public Library()
        {
            _booksRepository = new BooksRepository();
            _usersRepository = new UsersRepository();
            _archiveRepository = new ArchiveRepository();
        }

        public BookResponse AddBook(string title, string author, int yearOfPublication, string isbn, string genre)
        {
            var ids = _booksRepository.Books.Select(b => b.Id).OrderBy(b => b).ToList();
            var freeId = Enumerable.Range(1, ids.Count + 1).Except(ids).First();
            Book book = new Book(freeId, title, author, yearOfPublication, isbn, genre);

            int isbnCount = 0;
            foreach (Book repBook in _booksRepository.Books)
                if (book.Isbn == repBook.Isbn)
                    isbnCount++;
            if (isbnCount >= 2)
            {
                _booksRepository.Books.Remove(book);
                return BookResponse.IdentifierNotUnique;
            }

            if (book.YearOfPublication > DateTime.UtcNow.Year)
            {
                _booksRepository.Books.Remove(book);
                return BookResponse.IncorrectYear;
            }

            if (string.IsNullOrWhiteSpace(book.Title) || string.IsNullOrWhiteSpace(book.Author) || string.IsNullOrWhiteSpace(book.Isbn) || string.IsNullOrWhiteSpace(book.Genre))
            {
                _booksRepository.Books.Remove(book);
                return BookResponse.IncompleteInformations;
            }

            _booksRepository.Books.Add(book);
            return BookResponse.BookAdded;
        }

        public BookResponse RemoveBook(Book book)
        {
            if (!_booksRepository.Books.Contains(book))
                return BookResponse.BookNotFound;

            _booksRepository.Books.Remove(book);
            return BookResponse.BookRemoved;
        }

        public BookResponse UpdateBook(Book book, string updateValue, int updateType)
        {
            if (!_booksRepository.Books.Contains(book))
                return BookResponse.BookNotFound;

            if (string.IsNullOrWhiteSpace(updateValue))
                return BookResponse.UnacceptableValue;

            // 
            switch (updateType)
            {
                case 1:
                    if (updateValue.Length < 2 || string.IsNullOrEmpty(updateValue))
                        return BookResponse.UnacceptableValue;
                    book.Title = updateValue;
                    return BookResponse.BookUpdated;

                case 2:
                    if (updateValue.Length < 2 || string.IsNullOrEmpty(updateValue))
                        return BookResponse.UnacceptableValue;
                    book.Author = updateValue;
                    return BookResponse.BookUpdated;

                case 3:
                    if (int.TryParse(updateValue, out int updateYear))
                    {
                        if (updateYear > DateTime.UtcNow.Year)
                            return BookResponse.IncorrectYear;
                        else
                        {
                            book.YearOfPublication = updateYear;
                            return BookResponse.BookUpdated;
                        }
                    }
                    else
                        return BookResponse.UnacceptableValue;

                case 4:
                    if (updateValue.Length != 13)
                        return BookResponse.UnacceptableValue;
                    foreach (Book repBook in _booksRepository.Books)
                        if (updateValue == repBook.Isbn)
                            return BookResponse.IdentifierNotUnique;
                    book.Isbn = updateValue;
                    return BookResponse.BookUpdated;

                case 5:
                    if (updateValue.Length < 2 || string.IsNullOrEmpty(updateValue))
                        return BookResponse.UnacceptableValue;
                    book.Genre = updateValue;
                    return BookResponse.BookUpdated;

                default:
                    return BookResponse.IncorrectUpdateType;
            }
        }

        public IEnumerable<SimpleBook> GetAllBooks()
        {
            return _booksRepository.Books.Select(book => book.Map(book));
        }

        public Book GetBookById(int id)
        {
            return _booksRepository.Books.Where(book => book.Id == id).First();
        }

        public IEnumerable<SimpleBook> GetAvaibleBooks()
        {
            return _booksRepository.Books.Select(book => book.Map(book)).Where(book => book.Avaible == true);
        }

        public IEnumerable<Book> GetBorrowedBooks()
        {
            return _booksRepository.Books.Where(book => book.Avaible == false);
        }

        public IEnumerable<Book> GetUsersBorrowedBooks(User user)
        {
            return _booksRepository.Books.Where(book => book.Borrower == user);
        }

        public IEnumerable<User> GetUsers()
        {
            return _usersRepository.Users;
        }

        public IEnumerable<SimpleBook> SearchByTitle(string title)
        {
            return _booksRepository.Books.Select(book => book.Map(book)).Where(book => book.Title.Contains(title));
        }

        public IEnumerable<SimpleBook> SearchByAuthor(string author)
        {
            return _booksRepository.Books.Select(book => book.Map(book)).Where(book => book.Author.Contains(author));
        }

        public IEnumerable<SimpleBook> SearchByGenre(string genre)
        {
            return _booksRepository.Books.Select(book => book.Map(book)).Where(book => book.Genre.Contains(genre));
        }

        public BookResponse LendBook(User user, Book book)
        {
            if (user == null || book == null)
                return BookResponse.IncompleteInformations;

            if (!book.Avaible)
                return BookResponse.BookCurrentlyOnLoan;

            book.Avaible = false;
            book.BorrowDate = DateTime.UtcNow;
            book.ReturnDate = book.BorrowDate.Value.AddDays(60);
            book.Borrower = user;
            return BookResponse.BookLentSuccessfully;
        }

        public BookResponse ReceiveBook(User user, Book book)
        {
            if (user == null || book == null)
                return BookResponse.IncompleteInformations;

            if (book.Avaible || !user.BorrowedBooks.Contains(book))
                return BookResponse.BookIsNotOnLoan;

            _archiveRepository.AddToArchive(book);
            book.Avaible = true;
            book.BorrowDate = null;
            book.ReturnDate = null;
            book.Borrower = null;
            return BookResponse.BookReceivedSuccessfully;
        }

        public List<ArchivedRental> GetRentalArchive()
        {
            return _archiveRepository.ArchivedRentals;
        }

        public List<ArchivedRental> GetRentalArchiveByUser(User user)
        {
            return _archiveRepository.ArchivedRentals.Where(rental => rental.Borrower == user).ToList();
        }
    }
}
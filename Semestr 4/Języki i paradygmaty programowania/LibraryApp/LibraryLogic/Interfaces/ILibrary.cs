using LibraryLogic.Components;
using LibraryLogic.Objects;
using LibraryLogic.Repositories;
using LibraryLogic.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryLogic.Interfaces
{
    internal interface ILibrary
    {
        public BookResponse AddBook(string title, string author, int yearOfPublication, string isbn, string genre);
        public BookResponse RemoveBook(Book book);
        public BookResponse UpdateBook(Book book, string updateValue, int updateType);
        public IEnumerable<SimpleBook> GetAllBooks();
        public Book GetBookById(int id);
        public IEnumerable<SimpleBook> GetAvaibleBooks();
        public IEnumerable<Book> GetBorrowedBooks();
        public IEnumerable<Book> GetUsersBorrowedBooks(User user);
        public IEnumerable<User> GetUsers();
        public IEnumerable<SimpleBook> SearchByTitle(string title);
        public IEnumerable<SimpleBook> SearchByAuthor(string author);
        public IEnumerable<SimpleBook> SearchByGenre(string genre);
        public BookResponse LendBook(User user, Book book);
        public BookResponse ReceiveBook(User user, Book book);
        public List<ArchivedRental> GetRentalArchive();

        public List<ArchivedRental> GetRentalArchiveByUser(User user);

    }
}

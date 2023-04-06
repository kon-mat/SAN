using LibraryLogic.Components;
using LibraryLogic.Interfaces;
using LibraryLogic.Repositories;
using LibraryLogic.Responses;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryLogic.Objects
{
    public class User : IUser
    {
        private readonly int _id;
        private string _name;
        private string _surname;
        private List<Book> _borrowedBooks;

        public int Id { get { return _id; } }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public string Surname 
        {
            get { return _surname; }
            set { _surname = value; }
        }

        public List<Book> BorrowedBooks { get { return _borrowedBooks; } }

        public User(int id, string name, string surname)
        {
            _id = id;
            _name = name;
            _surname = surname;
            _borrowedBooks = new List<Book>();
        }

        public dynamic SearchByTitle(string title, Library library)
        {
            if (!string.IsNullOrWhiteSpace(title) || title.Length < 3)
                return InventoryRespone.TooShortSearchedValue;

            return library.SearchByAuthor(title);
        }

        public dynamic SearchByAuthor(string author, Library library)
        {
            if (!string.IsNullOrWhiteSpace(author) || author.Length < 3)
                return InventoryRespone.TooShortSearchedValue;

            return library.SearchByAuthor(author);
        }

        public dynamic SearchByGenre(string genre, Library library)
        {
            if (!string.IsNullOrWhiteSpace(genre) || genre.Length < 3)
                return InventoryRespone.TooShortSearchedValue;

            return library.SearchByAuthor(genre);
        }

        public IEnumerable<Book> GetUsersBorrowedBooks(Library library)
        {
            return library.GetUsersBorrowedBooks(this);
        }

        public BookResponse BoorrowBook(Book book, Library library)
        {
            if (library.LendBook(this, book) == BookResponse.BookLentSuccessfully)
            {
                _borrowedBooks.Add(book);
                return BookResponse.BookLentSuccessfully;
            }

            return library.LendBook(this, book);
        }

        public BookResponse ReturnBook(Book book, Library library)
        {
            if (!_borrowedBooks.Contains(book))
                return BookResponse.BookNotFound;

            if (library.ReceiveBook(this, book) == BookResponse.BookReceivedSuccessfully)
            {
                _borrowedBooks.Remove(book);
                return BookResponse.BookReceivedSuccessfully;
            }

            return library.ReceiveBook(this, book);
        }
    }
}

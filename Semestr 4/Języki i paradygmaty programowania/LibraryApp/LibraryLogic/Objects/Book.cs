using LibraryLogic.Objects;
using LibraryLogic.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LibraryLogic.Components
{
    public class Book
    {
        private readonly int _id;
        private string _title;
        private string _author;
        private DateTime _dateOfPublication;
        private string _isbn;
        private string _genre;
        private bool _avaible;
        private User? _borrower;
        private DateTime? _borrowDate;
        private DateTime? _returnDate;

        public int Id { get { return _id; } }

        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }

        public string Author
        {
            get { return _author; }
            set { _author = value; }
        }

        public int YearOfPublication
        { 
            get { return _dateOfPublication.Year; }
            set { _dateOfPublication = new DateTime(value, 1, 1); }
        }

        public string Isbn
        {
            get { return _isbn; }
            set { _isbn = value; }
        }

        public string Genre
        {
            get { return _genre; }
            set { _genre = value; }
        }

        public bool Avaible
        {
            get { return _avaible; }
            set { _avaible = value; }
        }

        public User? Borrower
        {
            get { return _borrower; }
            set { _borrower = value; }
        }

        public DateTime? BorrowDate
        {
            get { return _borrowDate; }
            set { _borrowDate = value; }
        }

        public DateTime? ReturnDate
        {
            get { return _returnDate; }
            set { _returnDate = value; }
        }

        public Book(int id, string title, string author, int yearOfPublication, string isbn, string genre)
        {
            _id = id;
            _title = title;
            _author = author;
            YearOfPublication = yearOfPublication;
            _isbn = isbn;
            _genre = genre;
            _avaible = true;
        }

        public SimpleBook Map(Book book)
        {
            return new SimpleBook(book.Id, book.Title, book.Author, book.Genre, book.Avaible);
        }
    }
}

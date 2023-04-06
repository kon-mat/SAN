using LibraryLogic.Components;
using LibraryLogic.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryLogic.Repositories
{
    internal class BooksRepository
    {
        private List<Book> _books;

        public List<Book> Books
        {
            get { return _books; }
        }

        public BooksRepository()
        {
            _books = new List<Book>()
            {
                new Book(1, "Manhattan Transfer", "John Dos Passos", 1925, "0-7891-5468-4", "Fiction"),
                new Book(2, "Bunner Sisters", "Edith Wharton", 1916, "0-4247-4381-7", "Classics"),
                new Book(3, "War with the Newts", "Karel Čapek", 1935, "0-3373-2691-6", "Satirical Science Fiction"),
                new Book(4, "Hadrian the Seventh", "Frederick Rolfe", 1904, "0-3571-0435-8", "Fiction"),
                new Book(5, "Inland", "Gerald Murnane", 1989, "0-9652-6048-8", "Westerns"),
                new Book(6, "Mosquitoland", "David Arnold", 2015, "0-7213-7442-5", "Youth literature"),
                new Book(7, "Two Kinds of Truth", "Michael Connelly", 2017, "0-3517-5163-7", "Novel"),
                new Book(8, "The Rose Code: A Novel", "Kate Quinn", 2021, "0-5224-1971-2", "Historical Fiction"),
                new Book(9, "Ready Player One", "Ernest Cline", 2011, "0-3215-5396-9", "Pop Culture Fiction"),
                new Book(10, "The Casual Vacancy", "J. K. Rowling", 2012, "0-3975-0687-2", "Tragicomedy")
            };
        }

        public BookResponse AddBook(string title, string author, int yearOfPublication, string isbn, string genre)
        {
            if (string.IsNullOrWhiteSpace(title) || string.IsNullOrWhiteSpace(author) || string.IsNullOrWhiteSpace(isbn) || string.IsNullOrWhiteSpace(genre))
                return BookResponse.IncompleteInformations;

            if (yearOfPublication > DateTime.UtcNow.Year)
                return BookResponse.IncorrectYear;

            if (isbn.Length != 13)
                return BookResponse.IncorectIsbnLength;

            if (_books.FindIndex(book => book.Isbn == isbn) > 0)
                return BookResponse.IdentifierNotUnique;

            var ids = _books.Select(b => b.Id).OrderBy(b => b).ToList();
            var freeId = Enumerable.Range(1, ids.Count).Except(ids).First();
            _books.Add(new Book(freeId, title, author, yearOfPublication, isbn, genre));
            return BookResponse.BookAdded;
        }

        public BookResponse RemoveBook(int id)
        {
            if (_books.Select(book => book.Id).Contains(id))
            {
                _books.RemoveAll(book => book.Id == id);
                return BookResponse.BookRemoved;
            }

            return BookResponse.BookNotFound;
        }

        public BookResponse UpdateBook(int id, string updateValue, int updateType)
        {
            int index = _books.FindIndex(book => book.Id == id);

            if (index < 0)
                return BookResponse.BookNotFound;

            if (string.IsNullOrWhiteSpace(updateValue))
                return BookResponse.UnacceptableValue;

            switch (updateType)
            {
                case 1:
                    if (updateValue.Length < 2)
                        return BookResponse.UnacceptableValue;
                    _books[index].Title = updateValue;
                    return BookResponse.BookUpdated;
                case 2:
                    if (updateValue.Length < 2)
                        return BookResponse.UnacceptableValue;
                    _books[index].Author = updateValue;
                    return BookResponse.BookUpdated;
                case 3:
                    if (int.TryParse(updateValue, out int updateYear))
                    {
                        if (updateYear > DateTime.UtcNow.Year)
                            return BookResponse.IncorrectYear;
                        else
                        {
                            _books[index].YearOfPublication = updateYear;
                            return BookResponse.BookUpdated;
                        }
                    }
                    else
                        return BookResponse.UnacceptableValue;
                case 4:
                    if (updateValue.Length != 13)
                        return BookResponse.IncorectIsbnLength;
                    if (_books.Select(book => book.Isbn == updateValue).Any())
                        return BookResponse.IdentifierNotUnique;
                    _books[index].Isbn = updateValue;
                    return BookResponse.BookUpdated;
                case 5:
                    _books[index].Genre = updateValue;
                    return BookResponse.BookUpdated;
                default:
                    return BookResponse.IncorrectUpdateType;
            }
        }

    }
}

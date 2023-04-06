using LibraryLogic.Components;
using LibraryLogic.Objects;
using LibraryLogic.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryLogic.Interfaces
{
    internal interface IUser
    {
        public dynamic SearchByTitle(string title, Library library);
        public dynamic SearchByAuthor(string author, Library library);
        public dynamic SearchByGenre(string genre, Library library);
        public IEnumerable<Book> GetUsersBorrowedBooks(Library library);
        public BookResponse BoorrowBook(Book book, Library library);
        public BookResponse ReturnBook(Book book, Library library);
    }
}

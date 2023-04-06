using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryLogic.Objects
{
    public class ArchivedRental
    {
        private int _id;
        private int _bookId;
        private User _borrower;
        private DateTime _borrowDate;
        private DateTime _returnDate;

        public int Id { get { return _id; } }
        public int BookId { get { return _id; } }
        public User Borrower { get { return _borrower; } }
        public DateTime BorrowDate { get { return _borrowDate; } }
        public DateTime ReturnDate { get { return _returnDate; } }

        public ArchivedRental(int id, int bookId, User borrower, DateTime borrowDate, DateTime returnDate)
        {
            (_id, _bookId, _borrower, _borrowDate, _returnDate) = (id, bookId, borrower, borrowDate, returnDate);
        }

    }
}

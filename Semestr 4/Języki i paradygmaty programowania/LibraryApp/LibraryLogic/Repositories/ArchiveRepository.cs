using LibraryLogic.Components;
using LibraryLogic.Interfaces;
using LibraryLogic.Objects;
using LibraryLogic.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryLogic.Repositories
{
    internal class ArchiveRepository
    {
        private List<ArchivedRental> _archivedRentals;
        public List<ArchivedRental> ArchivedRentals { get { return _archivedRentals; } }

        public ArchiveRepository()
        {
            _archivedRentals = new List<ArchivedRental>();
        }

        public InventoryRespone AddToArchive(Book borrowedBook)
        {
            if (borrowedBook.Borrower == null || borrowedBook.BorrowDate == null || borrowedBook.ReturnDate == null)
                return InventoryRespone.IncompleteInformations;

            var ids = _archivedRentals.Select(b => b.Id).OrderBy(b => b).ToList();
            var freeId = Enumerable.Range(1, ids.Count + 1).Except(ids).First();
            _archivedRentals.Add(new ArchivedRental(freeId, borrowedBook.Id ,borrowedBook.Borrower, borrowedBook.BorrowDate.Value, borrowedBook.ReturnDate.Value));
            return InventoryRespone.AddedToArchive;
        }
    }
}

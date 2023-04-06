using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryLogic.Responses
{
    public enum BookResponse
    {
        BookAdded,
        BookRemoved,
        BookUpdated,
        BookNotFound,
        IdentifierNotUnique,
        IncompleteInformations,
        IncorrectYear,
        IncorectIsbnLength,
        IncorrectUpdateType,
        UnacceptableValue,
        BookCurrentlyOnLoan,
        BookIsNotOnLoan,
        BookLentSuccessfully,
        BookReceivedSuccessfully,
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryLogic.Responses
{
    public enum UserResponse
    {
        UserAdded,
        UserRemoved,
        UserNotFound,
        UserUpdated,
        IncompleteInformations,
        NameTooShort,
        SurnameTooShort,
        UnacceptableValue,
        IncorrectUpdateType,
    }
}

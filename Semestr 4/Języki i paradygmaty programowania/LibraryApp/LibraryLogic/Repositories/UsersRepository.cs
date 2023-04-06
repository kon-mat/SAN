using LibraryLogic.Components;
using LibraryLogic.Objects;
using LibraryLogic.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryLogic.Repositories
{
    internal class UsersRepository
    {
        private List<User> _users;
        public List<User> Users { get { return _users; } }

        public UsersRepository()
        {
            _users = new List<User>()
            {
                new User(1, "Jan", "Kowalski"),
                new User(2, "Krystyna", "Brzoza"),
                new User(3, "Mariusz", "Konieczny")
            };
        }

        public UserResponse AddUser(string name, string surname)
        {
            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(surname))
                return UserResponse.IncompleteInformations;

            if (name.Length < 3)
                return UserResponse.NameTooShort;

            if (surname.Length < 3)
                return UserResponse.SurnameTooShort;

            var ids = _users.Select(u => u.Id).OrderBy(u => u).ToList();
            var freeId = Enumerable.Range(1, ids.Count + 1).Except(ids).First();
            _users.Add(new User(freeId, name, surname));
            return UserResponse.UserAdded;
        }

        public UserResponse RemoveUser(int id) 
        {
            if (_users.Select(user => user.Id).Contains(id))
            {
                _users.RemoveAll(user => user.Id == id);
                return UserResponse.UserRemoved;
            }

            return UserResponse.UserNotFound;
        }

        public UserResponse UpdateUser(int id, string updateValue, int updateType)
        {
            int index = _users.FindIndex(book => book.Id == id);

            if (index < 0)
                return UserResponse.UserNotFound;

            if (string.IsNullOrWhiteSpace(updateValue))
                return UserResponse.UnacceptableValue;

            switch (updateType)
            {
                case 1:
                    if (updateValue.Length < 3)
                        return UserResponse.NameTooShort;
                    _users[index].Name = updateValue;
                    return UserResponse.UserUpdated;
                case 2:
                    if (updateValue.Length < 3)
                        return UserResponse.SurnameTooShort;
                    _users[index].Surname = updateValue;
                    return UserResponse.UserUpdated;
                default:
                    return UserResponse.IncorrectUpdateType;
            }
        }

    }
}

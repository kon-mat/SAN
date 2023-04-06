using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Student : AuditableEntity
    {
        private int _id;
        private readonly string _pesel;
        private readonly string _firstName;
        private string _lastName;
        private List<Course> _courses;

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public string Pesel { get { return _pesel; } }

        public string FirstName { get { return _firstName; } }

        public string LastName 
        { 
            get { return _lastName; } 
            set { _lastName = value; }
        }

        public List<Course> Courses
        {
            get { return _courses; }
            set { _courses = value; }
        }

        public string FullName { get { return $"{_firstName} {_lastName}"; } }

        public Student() { }

        public Student(int id, string pesel, string firstName, string lastName)
        {
            (_id, _pesel, _firstName, _lastName) = (id, pesel, firstName, lastName);
            _courses = new List<Course>();
        }
    }
}

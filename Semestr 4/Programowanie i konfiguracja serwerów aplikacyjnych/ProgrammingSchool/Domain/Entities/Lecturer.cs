using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Lecturer : AuditableEntity
    {
        private int _id;
        private readonly string _pesel;
        private readonly string _firstName;
        private string _lastName;
        private int _salary;
        private string _degree;
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

        public string FullName { get { return $"{_firstName} {_lastName}"; } }

        public int Salary
        {
            get { return _salary; }
            set { _salary = value; }
        }

        public string Degree
        {
            get { return _degree; }
            set { _degree = value; }
        }

        public List<Course> Courses
        {
            get { return _courses; }
            set { _courses = value; }
        }

        public Lecturer() { }

        public Lecturer(int id, string pesel, string firstName, string lastName, int salary, string degree)
        {
            (_id, _pesel, _firstName, _lastName, _salary, _degree) = (id, pesel, firstName, lastName, salary, degree);
            _courses = new List<Course>();
        }
    }
}

using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class LecturerRepository : ILecturerRepository
    {
        private static readonly ISet<Lecturer> _lecturers = new HashSet<Lecturer>()
        {
            new Lecturer(1, "65081496175", "Jan", "Kowalski", 15000, "prof. dr hab. inż."),
            new Lecturer(2, "71020481777", "Andrzej", "Nowak", 8900, "dr"),
            new Lecturer(3, "78032915728", "Beata", "Strzelczyk", 11200, "dr inż.")
        };

        public IEnumerable<Lecturer> GetAll()
        {
            return _lecturers;
        }

        public Lecturer GetById(int id)
        {
            return _lecturers.SingleOrDefault(x => x.Id == id);
        }

        public Lecturer Add(Lecturer lecturer)
        {
            lecturer.Id = _lecturers.Count() + 1;
            lecturer.Created = DateTime.UtcNow;
            _lecturers.Add(lecturer);
            return lecturer;
        }

        public void Update(Lecturer lecturer)
        {
            lecturer.LastModified = DateTime.UtcNow;
        }

        public void Delete(Lecturer lecturer)
        {
            _lecturers.Remove(lecturer);
        }

        public void AddCourse(int id, Course course)
        {
            GetById(id).LastModified = DateTime.UtcNow;
            GetById(id).Courses.Add(course);
        }

        public void DeleteCourse(int id, Course course)
        {
            GetById(id).LastModified = DateTime.UtcNow;
            GetById(id).Courses.Remove(course);
        }
    }
}

using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private static ISet<Student> _students = new HashSet<Student>()
        {
            new Student(1, "94021981572", "Daniel", "Wójcik"),
            new Student(2, "01322964919", "Marcel", "Krajewska"),
            new Student(3, "01270241496", "Jarosław", "Wasilewska"),
            new Student(4, "90071043576", "Konrad", "Kaźmierczak"),
            new Student(5, "89082146587", "Danuta", "Urbańska"),
            new Student(6, "90011776441", "Luiza", "Mazur")
        };

        public IEnumerable<Student> GetAll()
        {
            return _students;
        }

        public Student GetById(int id)
        {
            return _students.FirstOrDefault(x => x.Id == id);
        }

        public Student Add(Student student)
        {
            student.Id = _students.Count() + 1;
            student.Created = DateTime.UtcNow;
            _students.Add(student);
            return student;
        }

        public void Update(Student student)
        {
            student.LastModified = DateTime.UtcNow;
        }

        public void Delete(Student student)
        {
            _students.Remove(student);
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

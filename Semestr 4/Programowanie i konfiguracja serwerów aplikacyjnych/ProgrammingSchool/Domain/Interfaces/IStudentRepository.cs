using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IStudentRepository
    {
        IEnumerable<Student> GetAll();
        Student GetById(int id);
        Student Add(Student student);
        void Update(Student student);
        void Delete(Student student);
        void AddCourse(int id, Course course);
        void DeleteCourse(int id, Course course);
    }
}

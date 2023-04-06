using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface ICourseRepository
    {
        IEnumerable<Course> GetAll();
        Course GetById(int id);
        Course Add(Course course);
        void Update(Lecturer lecturer);
        void Delete(Course course);
        void SetLecturer(int id, Lecturer lecturer);
        void AddStudent(int id, Student student);
        void DeleteStudent(int id, Student student);
    }
}

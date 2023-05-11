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
        void Update(Course course);
        void Delete(Course course);

        void AddStudent(int id, string student);
        void DeleteStudent(int id, string student);
    }
}

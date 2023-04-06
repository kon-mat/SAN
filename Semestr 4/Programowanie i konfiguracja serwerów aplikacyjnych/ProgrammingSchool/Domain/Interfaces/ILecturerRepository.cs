using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface ILecturerRepository
    {
        IEnumerable<Lecturer> GetAll();
        Lecturer GetById(int id);
        Lecturer Add(Lecturer lecturer);
        void Update(Lecturer lecturer);
        void Delete(Lecturer lecturer);
        void AddCourse(int id, Course course);
        void DeleteCourse(int id, Course course);
    }
}

using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class CourseRepository : ICourseRepository
    {
        private static ISet<Course> _courses = new HashSet<Course>()
        {
            new Course(1, Technology.JavaScript, Level.Beginner),
            new Course(2, Technology.CSharp, Level.Beginner),
            new Course(3, Technology.SQL, Level.Beginner),
        };

        public IEnumerable<Course> GetAll()
        {
            return _courses;
        }

        public Course GetById(int id)
        {
            return _courses.SingleOrDefault(x => x.Id == id);
        }

        public Course Add(Course course)
        {
            course.Id = _courses.Count() + 1;
            course.Created = DateTime.UtcNow;
            _courses.Add(course);
            return course;
        }

        public void Update(Course course)
        {
            course.LastModified = DateTime.UtcNow;
        }

        public void Delete(Course course)
        {
            throw new NotImplementedException();
        }

        public void AddStudent(int id, string student)
        {
            GetById(id).LastModified = DateTime.UtcNow;
            GetById(id).Students.Add(student);
        }

        public void DeleteStudent(int id, string student)
        {
            GetById(id).LastModified = DateTime.UtcNow;
            GetById(id).Students.Remove(student);
        }
    }
}

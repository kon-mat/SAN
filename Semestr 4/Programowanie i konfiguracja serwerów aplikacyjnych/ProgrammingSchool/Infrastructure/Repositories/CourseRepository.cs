using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class CourseRepository : ICourseRepository
    {
        private readonly SchoolContext _context;

        public CourseRepository(SchoolContext context)
        {
            _context = context;
        }

        public IEnumerable<Course> GetAll()
        {
            return _context.Courses;
        }

        public Course GetById(int id)
        {
            return _context.Courses.SingleOrDefault(x => x.Id == id);
        }

        public Course Add(Course course)
        {

            course.Created = DateTime.UtcNow;
            _context.Courses.Add(course);
            _context.SaveChanges();
            return course;
        }

        public void Update(Course course)
        {
            course.LastModified = DateTime.UtcNow;
            _context.Courses.Update(course);
            _context.SaveChanges();
        }

        public void Delete(Course course)
        {
            _context.Courses.Remove(course);
            _context.SaveChanges();
        }
    }
}
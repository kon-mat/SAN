using Application.Dto;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class CourseService : ICourseService
    {
        private readonly ICourseRepository _courseRepository;
        private readonly IMapper _mapper;

        public CourseService(ICourseRepository courseRepository, IMapper mapper)
        {
            _courseRepository = courseRepository;
            _mapper = mapper;
        }

        public IEnumerable<CourseDto> GetAllCourses()
        {
            var courses = _courseRepository.GetAll();
            return _mapper.Map<IEnumerable<CourseDto>>(courses);
        }

        public CourseDto GetCourseById(int id)
        {
            var course = _courseRepository.GetById(id);
            return _mapper.Map<CourseDto>(course);
        }

        public CourseDto AddNewCourse(CreateCourseDto newCourse)
        {
            if (string.IsNullOrEmpty(newCourse.Lecturer))
            {
                throw new Exception("The course cannot be created without an lecturer");
            } 
            if (!Enum.IsDefined(typeof(Technology), newCourse.Technology) || !Enum.IsDefined(typeof(Level), newCourse.Level))
            {
                throw new Exception("Technology and level must be included in the register");
            }

            var course = _mapper.Map<Course>(newCourse);
            _courseRepository.Add(course);
            return _mapper.Map<CourseDto>(course);
        }

        public void UpdateCourse(UpdateCourseDto updateCourse)
        {
            var existingCourse = _courseRepository.GetById(updateCourse.Id);
            var course = _mapper.Map(updateCourse, existingCourse);
            _courseRepository.Update(course);
        }

        public void DeleteCourse(int id)
        {
            var course = _courseRepository.GetById(id);
            _courseRepository.Delete(course);
        }
    }
}

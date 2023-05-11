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
    }
}

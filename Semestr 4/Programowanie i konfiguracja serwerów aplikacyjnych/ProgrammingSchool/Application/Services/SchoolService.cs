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
    public class SchoolService : ILecturerService, IStudentService, ICourseService
    {
        private readonly ILecturerRepository _lecturerRepository;
        private readonly IStudentRepository _studentRepository;
        private readonly ICourseRepository _courseRepository;
        private readonly IMapper _mapper;

        public SchoolService(ILecturerRepository lecturerRepository, IStudentRepository studentRepository, ICourseRepository courseRepository, IMapper mapper)
        {
            _lecturerRepository = lecturerRepository;
            _studentRepository = studentRepository;
            _courseRepository = courseRepository;
            _mapper = mapper;
        }

        public IEnumerable<LecturerDto> GetAllLecturers()
        {
            var lecturers = _lecturerRepository.GetAll();
            return _mapper.Map<IEnumerable<LecturerDto>>(lecturers);
        }

        public IEnumerable<StudentDto> GetAllStudents()
        {
            var students = _studentRepository.GetAll();
            return _mapper.Map<IEnumerable<StudentDto>>(students);
        }

        public IEnumerable<CourseDto> GetAllCourses()
        {
            var courses = _courseRepository.GetAll();
            return _mapper.Map<IEnumerable<CourseDto>>(courses);
        }

        public LecturerDto GetLecturerById(int id)
        {
            var lecturer = _lecturerRepository.GetById(id);
            return _mapper.Map<LecturerDto>(lecturer);
        }

        public StudentDto GetStudentById(int id)
        {
            var student = _studentRepository.GetById(id);
            return _mapper.Map<StudentDto>(student);
        }

        public CourseDto GetCourseById(int id)
        {
            var course = _courseRepository.GetById(id);
            return _mapper.Map<CourseDto>(course);
        }
    }
}

﻿using Application.Dto;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface ICourseService
    {
        IEnumerable<CourseDto> GetAllCourses();
        CourseDto GetCourseById(int id);
        CourseDto AddNewCourse(CreateCourseDto course);
        void UpdateCourse(UpdateCourseDto updateCourse);
        void DeleteCourse(int id);
    }
}

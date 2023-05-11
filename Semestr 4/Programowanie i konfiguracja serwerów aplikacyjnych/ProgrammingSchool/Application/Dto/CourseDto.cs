using Application.Mappings;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dto
{
    public class CourseDto : IMap
    {
        public int Id { get; set; }
        public Technology Technology { get; set; }
        public Level Level { get; set; }
        public string Lecturer { get; set; }
        public List<string> Students { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Course, CourseDto>();
        }
    }
}

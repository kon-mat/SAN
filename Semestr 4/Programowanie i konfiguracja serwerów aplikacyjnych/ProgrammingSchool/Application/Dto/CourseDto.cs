using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dto
{
    public class CourseDto
    {
        public int Id { get; set; }
        public Technology Technology { get; set; }
        public Level Level { get; set; }
        public Lecturer Lecturer { get; set; }
        public List<Student> Students { get; set; }
    }
}

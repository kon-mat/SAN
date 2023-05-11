using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dto
{
    public class UpdateCourseDto
    {
        public int Id { get; set; }
        public Level Level { get; set; }
        public string Lecturer { get; set; }
    }
}

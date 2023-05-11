using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Course : AuditableEntity
    {
        private int _id;
        private readonly Technology _technology;
        private Level _level;
        private string _lecturer;
        private List<string> _students;

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public Technology Technology { get { return _technology; } }

        public Level Level
        {
            get { return _level; }
            set { _level = value; }
        }

        public string Lecturer
        {
            get { return _lecturer; }
            set { _lecturer = value; }
        }

        public List<string> Students
        {
            get { return _students; }
            set { _students = value; }
        }

        public Course() { }

        public Course(int id, Technology technology, Level level)
        {
            (_id, _technology, _level) = (id, technology, level);
            _students = new List<string>();
        }
    }
}

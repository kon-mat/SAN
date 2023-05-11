using Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    
    [Table("Courses")]  // Atrybut Table służy do konfigurowania nazwy tabeli w bazie danych
    public class Course : AuditableEntity
    {
        [Key]  // Atrybut Key służy do wskazania klucza głównego w tabeli
        private int _id;

        [Required]  // Atrybutem Required definiujemy wymagalność danych
        [MaxLength(100)]    // Atrybut MaxLength definiuje maksymalną długość tekstu
        private readonly Technology _technology;

        [Required]
        [MaxLength(100)]
        private Level _level;

        [Required]
        [MaxLength(100)]
        private string _lecturer;

        [AllowNull] // Atrybut AllowNull zezwala na pozostawienie zmiennej jako pustej
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

        public Course() { }

        public Course(int id, Technology technology, Level level, string lecturer)
        {
            (_id, _technology, _level, _lecturer) = (id, technology, level, lecturer);
        }
    }
}

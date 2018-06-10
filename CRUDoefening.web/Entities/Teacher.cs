using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CRUDoefening.web.Entities
{
    public class Teacher
    {
        [Key] // not necessary if 'Id' is at the end of the property name
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        public string Name { get; set; }

        public decimal? YearlyWage { get; set; } // ? makes the decimal nullable

        public ICollection<Course> Courses { get; set; }

        public ICollection<Student> Students { get; set; }
    }
}

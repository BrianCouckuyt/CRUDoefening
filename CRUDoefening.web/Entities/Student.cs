using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CRUDoefening.web.Entities
{
    public class Student
    {
        [Key]
        public long Id { get; set; }
        public string Name { get; set; }
        public DateTime Birthdate { get; set; }
        public decimal? Scholarship { get; set; }
        public Teacher Teacher { get; set; }
        [ForeignKey("Teacher")]
        public long TeacherId { get; set; }
        public StudentInfo ContactInfo { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CRUDoefening.web.Entities
{
    public class StudentInfo
    {
        public long Id { get; set; }
        [ForeignKey("Student")]
        public long StudentId { get; set; }
        public string Email { get; set; }
        public Student Student { get; set; }
    }
}

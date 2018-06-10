using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CRUDoefening.web.Entities
{
    public class Course
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        [ForeignKey("Teacher")]
        public long TeacherId { get; set; }
        public Teacher Teacher { get; set; }
        public string Description { get; set; }
    }
}

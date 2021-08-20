using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection.Metadata;
using System.Threading.Tasks;

namespace WebDiary.Data.Models
{
    public class SchoolWorker
    {
        [Key, ForeignKey(nameof(Person))]
        public string Id { get; set; }
        public virtual Person Person { get; set; }

        public string RoleDescription { get; set; }

        public virtual ICollection<SchoolClass> Classes { get; set; } 
        public virtual ICollection<Subject> Subjects { get; set; }
        
    }
}

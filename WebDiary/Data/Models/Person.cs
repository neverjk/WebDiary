using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebDiary.Data.Models
{
    public class Person
    {
        [Key]
        [ForeignKey(nameof(UserProfile))]
        public string Id { get; set; }
        public virtual UserProfile UserProfile { get; set; }

        public virtual ICollection<School> Schools { get; set; }
        [StringLength(1000)]
        public string Description { get; set; }
        public bool IsActive { get; set; }

    }
}

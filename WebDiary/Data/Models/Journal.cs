using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebDiary.Data.Models
{
    public class Journal
    {
        [Key]
        [ScaffoldColumn(false)]
        public string Id { get; set; }

        [ForeignKey("Subject")]
        public int SubjectId { get; set; }
        public virtual Subject Subject { get; set; }

        public virtual ICollection<Mark> Current { get; set; }
        public virtual ICollection<Mark> Semester1 { get; set; }
        public virtual ICollection<Mark> Semester2 { get; set; }
        public virtual ICollection<Mark> Final { get; set; }

    }
}

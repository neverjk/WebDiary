﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebDiary.Data.Models
{
    public class SchoolClass
    {
        [Key]
        [ScaffoldColumn(false)]
        public string Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime FinalDate { get; set; }

        [ForeignKey("School")]
        public string SchoolId { get; set; }
        public virtual School School { get; set; }
        [ForeignKey("Teacher")]
        public string TeacherId { get; set; }
        public virtual SchoolWorker Teacher { get; set; }

        public virtual ICollection<SchoolClassStudent> SchoolClassStudents { get; set; }
        public virtual ICollection<Subject> Subjects { get; set; }
        public virtual ICollection<Schedule> Schedules { get; set; }
    }
}

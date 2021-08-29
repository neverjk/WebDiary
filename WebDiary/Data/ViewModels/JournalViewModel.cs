﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebDiary.Data.Models;

namespace WebDiary.Data.ViewModels
{
    public class JournalViewModel
    {
        public Journal GetJournal { get; set; }
        public ICollection<Mark> Semester1 { get; set; }
        public ICollection<Mark> Semester2 { get; set; }
        public ICollection<Mark> Final { get; set; }
        public ICollection<Mark> Current { get; set; }
        public Subject Subject { get; set; }
    }
}

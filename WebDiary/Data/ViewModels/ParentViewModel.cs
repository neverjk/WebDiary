using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebDiary.Data.Models;

namespace WebDiary.Data.ViewModels
{
    public class ParentViewModel
    {
        public Parent GetParent { get; set; }
        public IEnumerable<Student> Kids { get; set; }
    }
}

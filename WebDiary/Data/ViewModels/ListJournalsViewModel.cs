using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebDiary.Data.ViewModels
{
    public class ListJournalsViewModel
    {
        public IEnumerable<JournalViewModel> GetJournals { get; set; }
    }
}

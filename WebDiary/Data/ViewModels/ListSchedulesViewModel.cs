using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebDiary.Data.ViewModels
{
    public class ListSchedulesViewModel
    {
        public IEnumerable<ScheduleViewModel> GetSchedules { get; set; }
    }
}

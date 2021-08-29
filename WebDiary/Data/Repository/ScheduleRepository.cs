using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebDiary.Data.EFContext;
using WebDiary.Data.Interfaces;
using WebDiary.Data.Models;

namespace WebDiary.Data.Repository
{
    public class ScheduleRepository : ISchedule
    {
        private readonly EFDbContext _context;

        public ScheduleRepository(EFDbContext dbContext)
        {
            _context = dbContext;
        }

        public IEnumerable<Schedule> GetSchedules => _context.Schedules
            .Include(x => x.SchoolClass)
            .Include(x => x.Lessons).ThenInclude(x=>x.Subject);

    }
}

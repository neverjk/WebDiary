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
    public class JournalRepository : IJournal
    {
        private readonly EFDbContext _context;

        public JournalRepository(EFDbContext dbContext)
        {
            _context = dbContext;
        }

        public IEnumerable<Journal> GetJournals => _context.Journals
            .Include(x => x.Current)
            .Include(x => x.Semester1)
            .Include(x => x.Semester2)
            .Include(x => x.Final)
            .Include(x => x.Subject).ThenInclude(x => x.SchoolClass)
            .Include(x => x.Subject).ThenInclude(x => x.Teacher)
            .Include(x => x.Subject).ThenInclude(x => x.Students);
    }
}

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
    public class SchoolRepository : ISchool
    {
        private readonly EFDbContext _context;

        public SchoolRepository(EFDbContext dbContext)
        {
            _context = dbContext;
        }
        public IEnumerable<School> GetSchools => _context.Schools
            .Include(x => x.Students)
            .Include(x => x.SchoolWorkers)
            .Include(x => x.Director);

    }
}

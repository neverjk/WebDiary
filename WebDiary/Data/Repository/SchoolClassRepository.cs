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
    public class SchoolClassRepository :ISchoolClass
    {
        private readonly EFDbContext _context;

        public SchoolClassRepository(EFDbContext dbContext)
        {
            _context = dbContext;
        }
        public IEnumerable<SchoolClass> GetSchoolClasses => _context.SchoolClasses
            .Include(x => x.Students)
            .Include(x => x.Teacher)
            .Include(x => x.School)
            .Include(x => x.Subjects);

    }
}

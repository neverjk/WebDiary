using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebDiary.Data.Interfaces;
using WebDiary.Data.Models;
using WebDiary.Data.ViewModels;

namespace WebDiary.Controllers
{
    public class JournalController : Controller
    {
        private readonly IJournal _journals;
        public JournalController(IJournal journals)
        {
            _journals = journals;
        }
        [Route("Journal/GetJournalsStudent")]
        public ViewResult GetJournalsStudent (Student studentId)
        {
            //var info = HttpContext.Session.GetString("UserInfo");
            //if (info != null)
            //{
            //    var result = JsonConvert.DeserializeObject<UserInfo>(info);
            //    var id = result.UserId;
            //}

            IEnumerable<Journal> journals = null;
            List<JournalViewModel> journalViewModels = null;
            if (string.IsNullOrEmpty(studentId.Id))
            {

            }
            else
            {
                journals = _journals.GetJournals.Where(x => x.Subject.SchoolClass.Students.Contains(studentId));
                foreach(Journal j in journals)
                {
                    journalViewModels.Add(new JournalViewModel { GetJournal = j, Current = j.Current, Final = j.Final, Semester1 = j.Semester1, Semester2 = j.Semester2, Subject = j.Subject });
                }
                //if (string.Equals("Benzin", category, StringComparison.OrdinalIgnoreCase))
                //{
                //    cars = _cars.GetCars.Where(x => x.Category.CategoryName.Equals("Benzin"))
                //        .OrderBy(i => i.Id);
                //}
                //else if (string.Equals("Diezel", category, StringComparison.OrdinalIgnoreCase))
                //{
                //    cars = _cars.GetCars.Where(x => x.Category.CategoryName.Equals("Diezel"))
                //        .OrderBy(i => i.Id);
                //}
                //else
                //{
                //    cars = _cars.GetCars.Where(x => x.Category.CategoryName.Equals("Electro"))
                //        .OrderBy(i => i.Id);
                //}
            }
            var journalsObj = new ListJournalsViewModel { GetJournals = journalViewModels };
            return View(journalsObj);




        }

        [Route("Journal/GetJournalsTeacher")]
        public ViewResult GetJournalsTeacher(SchoolWorker teacherId)
        {
            //var info = HttpContext.Session.GetString("UserInfo");
            //if (info != null)
            //{
            //    var result = JsonConvert.DeserializeObject<UserInfo>(info);
            //    var id = result.UserId;
            //}

            IEnumerable<Journal> journals = null;
            List<JournalViewModel> journalViewModels = null;
            if (string.IsNullOrEmpty(teacherId.Id))
            {

            }
            else
            {
                journals = _journals.GetJournals.Where(x => x.Subject.Teacher==teacherId);
                foreach (Journal j in journals)
                {
                    journalViewModels.Add(new JournalViewModel { GetJournal = j, Current = j.Current, Final = j.Final, Semester1 = j.Semester1, Semester2 = j.Semester2, Subject = j.Subject });
                }
                //if (string.Equals("Benzin", category, StringComparison.OrdinalIgnoreCase))
                //{
                //    cars = _cars.GetCars.Where(x => x.Category.CategoryName.Equals("Benzin"))
                //        .OrderBy(i => i.Id);
                //}
                //else if (string.Equals("Diezel", category, StringComparison.OrdinalIgnoreCase))
                //{
                //    cars = _cars.GetCars.Where(x => x.Category.CategoryName.Equals("Diezel"))
                //        .OrderBy(i => i.Id);
                //}
                //else
                //{
                //    cars = _cars.GetCars.Where(x => x.Category.CategoryName.Equals("Electro"))
                //        .OrderBy(i => i.Id);
                //}
            }
            var journalsObj = new ListJournalsViewModel { GetJournals = journalViewModels };
            return View(journalsObj);




        }

        [Route("Journal/GetJournal")]
        public ViewResult GetJournal(string journalId)
        {
            //var info = HttpContext.Session.GetString("UserInfo");
            //if (info != null)
            //{
            //    var result = JsonConvert.DeserializeObject<UserInfo>(info);
            //    var id = result.UserId;
            //}

            Journal journal = null;
            if (string.IsNullOrEmpty(journalId))
            {

            }
            else
            {
                journal = _journals.GetJournals.FirstOrDefault(x => x.Id.ToLower() == journalId.ToLower());
                
            }
            var journalsObj = new JournalViewModel { GetJournal = journal, Current = journal.Current, Final = journal.Final, Semester1 = journal.Semester1, Semester2 = journal.Semester2, Subject = journal.Subject };
            return View(journalsObj);
        }
    }
}
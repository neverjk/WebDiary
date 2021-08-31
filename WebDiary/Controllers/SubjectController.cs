using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebDiary.Data.Interfaces;
using WebDiary.Data.Models;
using WebDiary.Data.ViewModels;

namespace WebDiary.Controllers
{
    public class SubjectController : Controller
    {
        private readonly ISubject _subjects;
        public SubjectController(ISubject subjects)
        {
            _subjects = subjects;
        }
        [Route("Subject/GetSubject")]
        public ViewResult GetSubject(string subjectId)
        {
            Subject subject = null;
            if (string.IsNullOrEmpty(subjectId))
            {

            }
            else
            {
                subject = _subjects.GetSubjects.FirstOrDefault(x => x.Id.ToLower() == subjectId.ToLower());

            }
            var subjectObj = new SubjectViewModel
            {
                GetSubject = subject,
                SchoolClass = subject.SchoolClass,
                Teacher = subject.Teacher
            };
            return View(subjectObj);
        }

        [Route("Subject/GetSubjectsStudent")]
        public ViewResult GetSubjectsStudent(Student studentId)
        {
            //var info = HttpContext.Session.GetString("UserInfo");
            //if (info != null)
            //{
            //    var result = JsonConvert.DeserializeObject<UserInfo>(info);
            //    var id = result.UserId;
            //}

            IEnumerable<Subject> subjects = null;
            List<SubjectViewModel> subjectsViewModels = null;
            if (string.IsNullOrEmpty(studentId.Id))
            {

            }
            else
            {
                subjects = _subjects.GetSubjects.Where(x => x.SchoolClass.Students.Contains(studentId));
                foreach (Subject s in subjects)
                {
                    subjectsViewModels.Add(new SubjectViewModel { GetSubject = s, Teacher = s.Teacher, SchoolClass = s.SchoolClass });
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
            var subjectsObj = new ListSubjectViewModel { GetSubjects = subjectsViewModels };
            return View(subjectsObj);
        }

        [Route("Subject/GetSubjectsTeacher")]
        public ViewResult GetSubjectsTeacher(SchoolWorker schoolWorkerId)
        {
            //var info = HttpContext.Session.GetString("UserInfo");
            //if (info != null)
            //{
            //    var result = JsonConvert.DeserializeObject<UserInfo>(info);
            //    var id = result.UserId;
            //}

            IEnumerable<Subject> subjects = null;
            List<SubjectViewModel> subjectViewModels = null;
            if (string.IsNullOrEmpty(schoolWorkerId.Id))
            {

            }
            else
            {
                subjects = _subjects.GetSubjects.Where(x => x.Teacher.Id.ToLower() == schoolWorkerId.Id.ToLower());
                foreach (Subject s in subjects)
                {
                    subjectViewModels.Add(new SubjectViewModel { GetSubject = s, Teacher = s.Teacher, SchoolClass = s.SchoolClass });
                }
            }
            var subjectsObj = new ListSubjectViewModel { GetSubjects = subjectViewModels };
            return View(subjectsObj);

        }
    }
}

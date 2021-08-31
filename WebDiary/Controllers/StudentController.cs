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
    public class StudentController : Controller
    {
        private readonly IStudent _students;
        public StudentController(IStudent students)
        {
            _students = students;
        }
        [Route("Student/GetStudent")]
        public ViewResult GetStudent(string studentId)
        {
            //var info = HttpContext.Session.GetString("UserInfo");
            //if (info != null)
            //{
            //    var result = JsonConvert.DeserializeObject<UserInfo>(info);
            //    var id = result.UserId;
            //}

            Student student = null;
            if (string.IsNullOrEmpty(studentId))
            {

            }
            else
            {
                student = _students.GetStudents.FirstOrDefault(x => x.Id.ToLower() == studentId.ToLower());

            }
            var studentsObj = new StudentViewModel { GetStudent=student, SchoolClasses=student.SchoolClasses };
            return View(studentsObj);
        }

        [Route("Student/GetStudentsClass")]
        public ViewResult GetStudentsClass(SchoolClass schoolClass)
        {
            //var info = HttpContext.Session.GetString("UserInfo");
            //if (info != null)
            //{
            //    var result = JsonConvert.DeserializeObject<UserInfo>(info);
            //    var id = result.UserId;
            //}

            IEnumerable<Student> students = null;
            List<StudentViewModel> studentViewModels = null;
            if (string.IsNullOrEmpty(schoolClass.Id))
            {

            }
            else
            {
                students = _students.GetStudents.Where(x => x.SchoolClasses.Contains(schoolClass));
                foreach(Student s in students)
                {
                    studentViewModels.Add(new StudentViewModel { GetStudent = s, SchoolClasses = s.SchoolClasses });
                }
            }
            var studentsObj = new ListStudentViewModel { GetStudents = studentViewModels, SchoolClass = schoolClass };
            return View(studentsObj);
        }

        [Route("Student/GetStudentsSchool")]
        public ViewResult GetStudentsSchool(School school)
        {
            //var info = HttpContext.Session.GetString("UserInfo");
            //if (info != null)
            //{
            //    var result = JsonConvert.DeserializeObject<UserInfo>(info);
            //    var id = result.UserId;
            //}

            IEnumerable<Student> students = null;
            List<StudentViewModel> studentViewModels = null;
            if (string.IsNullOrEmpty(school.Id))
            {

            }
            else
            {
                foreach (Student s in students)
                {
                    foreach(SchoolClass s1 in s.SchoolClasses)
                    {
                        if (s1.School.Id.ToLower() == school.Id.ToLower())
                        {
                            studentViewModels.Add(new StudentViewModel { GetStudent = s, SchoolClasses = s.SchoolClasses });
                        }
                    }
                    
                }
            }
            var studentsObj = new ListStudentViewModel { GetStudents = studentViewModels, SchoolClass = null };
            return View(studentsObj);
        }

        [Route("Student/GetStudentsSubject")]
        public ViewResult GetStudentsSubject(Subject subject)
        {
            //var info = HttpContext.Session.GetString("UserInfo");
            //if (info != null)
            //{
            //    var result = JsonConvert.DeserializeObject<UserInfo>(info);
            //    var id = result.UserId;
            //}

            IEnumerable<Student> students = null;
            List<StudentViewModel> studentViewModels = null;
            if (string.IsNullOrEmpty(subject.Id))
            {

            }
            else
            {
                foreach (Student s in students)
                {
                    foreach (Subject s1 in s.Subjects)
                    {
                        if (s1.Id.ToLower() == subject.Id.ToLower())
                        {
                            studentViewModels.Add(new StudentViewModel { GetStudent = s, SchoolClasses = s.SchoolClasses });
                        }
                    }

                }
            }
            var studentsObj = new ListStudentViewModel { GetStudents = studentViewModels, SchoolClass = null };
            return View(studentsObj);
        }

        
    }
}

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
            List<SchoolClass> schoolClasses = null;
            if (string.IsNullOrEmpty(studentId))
            {

            }
            else
            {
                student = _students.GetStudents.FirstOrDefault(x => x.Id.ToLower() == studentId.ToLower());
                foreach(Student s in _students.GetStudents)
                {
                    foreach(SchoolClassStudent sc in s.SchoolClassStudents)
                    {
                        schoolClasses.Add(sc.SchoolClass);
                    }
                }

            }
            var studentsObj = new StudentViewModel { GetStudent=student, SchoolClasses= schoolClasses };
            return View(studentsObj);
        }

        [Route("Student/GetStudentsClass")]
        public ViewResult GetStudentsClass(string schoolClassId)
        {
            //var info = HttpContext.Session.GetString("UserInfo");
            //if (info != null)
            //{
            //    var result = JsonConvert.DeserializeObject<UserInfo>(info);
            //    var id = result.UserId;
            //}

            List<Student> students = null;
            SchoolClass schoolClass1 = null;
            if (string.IsNullOrEmpty(schoolClassId))
            {

            }
            else
            {

                //students = _students.GetStudents.Where(x => x.SchoolClasses.Contains(schoolClass));
                foreach (Student s in _students.GetStudents)
                {
                    foreach(SchoolClassStudent sc in s.SchoolClassStudents)
                    {
                        if (sc.SchoolClass.Id.ToLower() == schoolClassId.ToLower())
                        {
                            students.Add(s);
                            schoolClass1 = sc.SchoolClass;
                        }
                    }
                }
                
            }
            var studentsObj = new ListStudentViewModel { GetStudents = students, SchoolClass = schoolClass1, Subject=null, School=null };
            return View(studentsObj);
        }

        [Route("Student/GetStudentsSchool")]
        public ViewResult GetStudentsSchool(string schoolId)
        {
            //var info = HttpContext.Session.GetString("UserInfo");
            //if (info != null)
            //{
            //    var result = JsonConvert.DeserializeObject<UserInfo>(info);
            //    var id = result.UserId;
            //}

            List<Student> students = null;
            School school = null;
            if (string.IsNullOrEmpty(schoolId))
            {

            }
            else
            {
                foreach (Student s in students)
                {
                    foreach(SchoolClassStudent s1 in s.SchoolClassStudents)
                    {
                        if (s1.SchoolClass.School.Id.ToLower() == schoolId.ToLower())
                        {
                            students.Add(s);
                            school = s1.SchoolClass.School;
                        }
                    }
                    
                }
            }
            var studentsObj = new ListStudentViewModel { GetStudents = students, School=school, Subject=null, SchoolClass=null };
            return View(studentsObj);
        }

        [Route("Student/GetStudentsSubject")]
        public ViewResult GetStudentsSubject(string subjectId)
        {
            //var info = HttpContext.Session.GetString("UserInfo");
            //if (info != null)
            //{
            //    var result = JsonConvert.DeserializeObject<UserInfo>(info);
            //    var id = result.UserId;
            //}

            List<Student> students = null;
            Subject subject = null;
            if (string.IsNullOrEmpty(subjectId))
            {

            }
            else
            {
                foreach (Student s in students)
                {
                    foreach (StudentSubject s1 in s.StudentSubjects)
                    {
                        if (s1.Subject.Id.ToLower() == subjectId.ToLower())
                        {
                            students.Add(s);
                            subject = s1.Subject;
                        }
                    }

                }
            }
            var studentsObj = new ListStudentViewModel { GetStudents = students, SchoolClass = null, Subject=subject, School=null };
            return View(studentsObj);
        }

        
    }
}

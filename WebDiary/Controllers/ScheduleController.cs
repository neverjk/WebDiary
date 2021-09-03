using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebDiary.Data.Interfaces;
using WebDiary.Data.Models;
using WebDiary.Data.ViewModels;

namespace WebDiary.Controllers
{
    public class ScheduleController : Controller
    {
        private readonly ISchedule _schedules;
        public ScheduleController(ISchedule schedules)
        {
            _schedules = schedules;
        }
        [Route("Schedule/GetSchedule")]
        public ViewResult GetSchedule(string scheduleId)
        {
            Schedule schedule = null;
            if (string.IsNullOrEmpty(scheduleId))
            {

            }
            else
            {
                schedule = _schedules.GetSchedules.FirstOrDefault(x => x.Id.ToLower() == scheduleId.ToLower());

            }
            var scheduleObj = new ScheduleViewModel
            {
                GetSchedule = schedule,
                Lessons = schedule.Lessons,
                SchoolClass = schedule.SchoolClass

            };
            return View(scheduleObj);
        }

        [Route("Schedule/GetSchedulesStudent")]
        public ViewResult GetSchedulesStudent(string studentId)
        {
            //var info = HttpContext.Session.GetString("UserInfo");
            //if (info != null)
            //{
            //    var result = JsonConvert.DeserializeObject<UserInfo>(info);
            //    var id = result.UserId;
            //}

            List<Schedule>  schedules = null;
            List<ScheduleViewModel> scheduleViewModels = null;
            if (string.IsNullOrEmpty(studentId))
            {

            }
            else
            {
                foreach(Schedule s in _schedules.GetSchedules)
                {
                    foreach(SchoolClassStudent sc in s.SchoolClass.SchoolClassStudents)
                    {
                        if (sc.Student.Id.ToLower() == studentId.ToLower())
                        {
                            schedules.Add(s);
                        }

                    }
                }
                
                foreach (Schedule s in schedules)
                {
                    scheduleViewModels.Add(new ScheduleViewModel {  GetSchedule=s, Lessons=s.Lessons, SchoolClass=s.SchoolClass});
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
            var schedulesObj = new ListSchedulesViewModel { GetSchedules = scheduleViewModels };
            return View(schedulesObj);




        }

        [Route("Schedule/GetSchedulesTeacher")]
        public ViewResult GetSchedulesTeacher(SchoolWorker schoolWorkerId)
        {
            //var info = HttpContext.Session.GetString("UserInfo");
            //if (info != null)
            //{
            //    var result = JsonConvert.DeserializeObject<UserInfo>(info);
            //    var id = result.UserId;
            //}

            List<Schedule> schedules = null;
            List<ScheduleViewModel> scheduleViewModels = null;
            if (string.IsNullOrEmpty(schoolWorkerId.Id))
            {

            }
            else
            {
                //schedules = _schedules.GetSchedules.Where(x => x.Lessons.); ;
                foreach(Schedule s in schedules)
                {
                    foreach(Lesson l in s.Lessons)
                    {
                        if (l.Subject.Teacher.Id.ToLower() == schoolWorkerId.Id.ToLower())
                        {

                            schedules.Add(s);
                        }
                    }
                }
                foreach (Schedule s in schedules)
                {
                    scheduleViewModels.Add(new ScheduleViewModel { GetSchedule = s, Lessons = s.Lessons, SchoolClass = s.SchoolClass });
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
            var schedulesObj = new ListSchedulesViewModel { GetSchedules = scheduleViewModels };
            return View(schedulesObj);




        }
    }
}
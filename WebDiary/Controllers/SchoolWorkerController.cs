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
    public class SchoolWorkerController : Controller
    {
        private readonly ISchoolWorker _schoolWorkers;
        public SchoolWorkerController(ISchoolWorker schoolWorkers)
        {
            _schoolWorkers = schoolWorkers;
        }
        [Route("SchoolWorker/GetSchoolWorker")]
        public ViewResult GetSchoolWorker(string schoolWorkerId)
        {
            //var info = HttpContext.Session.GetString("UserInfo");
            //if (info != null)
            //{
            //    var result = JsonConvert.DeserializeObject<UserInfo>(info);
            //    var id = result.UserId;
            //}

            SchoolWorker schoolWorker = null;
            if (string.IsNullOrEmpty(schoolWorkerId))
            {

            }
            else
            {
                schoolWorker = _schoolWorkers.GetSchoolWorkers.FirstOrDefault(x => x.Id.ToLower() == schoolWorkerId.ToLower());

            }
            var schoolWorkerObj = new SchoolWorkerViewModel { GetSchoolWorker = schoolWorker, Classes = schoolWorker.Classes, Subjects = schoolWorker.Subjects };
            return View(schoolWorkerObj);
        }

        [Route("SchoolWorker/GetSchoolWorkersSchool")]
        public ViewResult GetSchoolWorkersSchool(School schoolId)
        {
            //var info = HttpContext.Session.GetString("UserInfo");
            //if (info != null)
            //{
            //    var result = JsonConvert.DeserializeObject<UserInfo>(info);
            //    var id = result.UserId;
            //}

            List<SchoolWorker> schoolWorkers = null;
            if (string.IsNullOrEmpty(schoolId.Id))
            {

            }
            else
            {
                foreach (SchoolWorker s in _schoolWorkers.GetSchoolWorkers)
                {
                    foreach(Subject s1 in s.Subjects)
                    {
                        if (s1.SchoolClass.School.Id.ToLower() == schoolId.Id.ToLower())
                        {
                            schoolWorkers.Add(s);
                        }
                    }
                }

            }
            var schoolWorkerObj = new ListSchoolWorkerViewModel { GetSchoolWorkers=schoolWorkers, School=schoolId };
            return View(schoolWorkerObj);
        }

        [Route("SchoolWorker/GetSchoolWorkersClass")]
        public ViewResult GetSchoolWorkersClass(SchoolClass schoolClassId)
        {
            //var info = HttpContext.Session.GetString("UserInfo");
            //if (info != null)
            //{
            //    var result = JsonConvert.DeserializeObject<UserInfo>(info);
            //    var id = result.UserId;
            //}

            IEnumerable<SchoolWorker> schoolWorkers = null;
            School _school = null;
            if (string.IsNullOrEmpty(schoolClassId.Id))
            {

            }
            else
            {
                schoolWorkers = _schoolWorkers.GetSchoolWorkers.Where(x => x.Classes.Contains(schoolClassId));
                _school = schoolClassId.School;

            }
            var schoolWorkerObj = new ListSchoolWorkerViewModel { GetSchoolWorkers = schoolWorkers, School = _school };
            return View(schoolWorkerObj);
        }
    }
}
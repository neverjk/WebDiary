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
    public class SchoolController : Controller
    {
        private readonly ISchool _schools;
        public SchoolController(ISchool schools)
        {
            _schools = schools;
        }
        [Route("School/GetSchool")]
        public ViewResult GetSchool(string schoolId)
        {
            //var info = HttpContext.Session.GetString("UserInfo");
            //if (info != null)
            //{
            //    var result = JsonConvert.DeserializeObject<UserInfo>(info);
            //    var id = result.UserId;
            //}

            School school = null;
            if (schoolId==null)
            {

            }
            else
            {
                school = _schools.GetSchools.FirstOrDefault(x => x.Id.ToLower() == schoolId.ToLower());

            }
            var schoolObj = new SchoolViewModel { GetSchool = school };
            return View(schoolObj);
        }

        [Route("School/GetSchoolList")]
        public ViewResult GetSchoolList()
        {
            //var info = HttpContext.Session.GetString("UserInfo");
            //if (info != null)
            //{
            //    var result = JsonConvert.DeserializeObject<UserInfo>(info);
            //    var id = result.UserId;
            //}

            IEnumerable<School> schools = null;
            schools = _schools.GetSchools.OrderBy(x => x.Name);

            var schoolObj = new ListSchoolViewModel
            {
                GetSchools = schools
            };
            return View(schoolObj);
        }
    }
}

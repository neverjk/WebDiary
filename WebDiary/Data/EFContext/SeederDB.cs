using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebDiary.Data.Models;

namespace WebDiary.Data.EFContext
{
    public class SeederDB
    {
        public static void SeedUsers(UserManager<DbUser> userManager,
            EFDbContext _context)
        {

            var count = userManager.Users.Count();
            if (count <= 0)
            {
                string email = "fvllenleaves@gmail.com";
                var roleName = "Admin";
                var userprofile = new UserProfile
                {
                    FirstName = "admin",
                    LastName = "admin",
                    MiddleName = "admin",
                    RegistrationDate = DateTime.Now,
                    Gender = "Male",
                    BirthDate = DateTime.Now.AddYears(-45).AddDays(-38)
                };
                var user = new DbUser
                {
                    Email = email,
                    UserName = email,
                    PhoneNumber = "+38(095)890-10-45",
                    UserProfile = userprofile
                };
                _context.UserProfiles.Add(userprofile);
                var result = userManager.CreateAsync(user, "Qwerty1-").Result;
                result = userManager.AddToRoleAsync(user, roleName).Result;
                _context.SaveChanges();

                var school = new School
                {
                    Name = "King's College London Maths School",
                    Address = "80 Kennington Road, London, SE11 6NJ",
                    Description = "King's College London Mathematics School is a free school sixth form located in the Lambeth area of London, England. King's College London Mathematics School is run in partnership with King's College London University, to provide high quality mathematics education in London.",
                    PhoneNumber = "+44 20 7848 7346",
                    Email = "kingscollegelondonmathsschool@gmail.com",
                    Type = "Academy school Coeducational",
                    SchoolWorkers = new List<SchoolWorker>(),
                    SchoolStudents = new List<SchoolStudent>(),
                    Classes = new List<SchoolClass>()
                };
                _context.Schools.Add(school);
                _context.SaveChanges();

                var Directoremail = "bethaniemedina@gmail.com";
                var DirectorroleName = "Director";
                var Directoruserprofile = new UserProfile
                {
                    FirstName = "Bethanie",
                    LastName = "Medina",
                    MiddleName = "Saoirse",
                    RegistrationDate = DateTime.Now,
                    Gender = "Female",
                    BirthDate = DateTime.Now.AddYears(-48).AddDays(25)
                };
                var Directoruser = new DbUser
                {
                    Email = Directoremail,
                    UserName = Directoremail,
                    PhoneNumber = "+1 224-698-6579",
                    UserProfile = Directoruserprofile
                };
                _context.UserProfiles.Add(Directoruserprofile);
                result = userManager.CreateAsync(Directoruser, "Qwerty1-").Result;
                result = userManager.AddToRoleAsync(Directoruser, DirectorroleName).Result;
                result = userManager.AddToRoleAsync(Directoruser, "Teacher").Result;
                result = userManager.AddToRoleAsync(Directoruser, "SchoolWorker").Result;
                _context.SaveChanges();
                var Directorperson = new Person { UserProfile = Directoruserprofile, IsActive = true };
                _context.Persons.Add(Directorperson);
                var DirectorschoolWorker = new SchoolWorker { Person = Directorperson, RoleDescription = "Director and Geography teacher", Subjects = new List<Subject>(), IsDirector = true, IsClassTeacher = false };
                _context.SchoolWorkers.Add(DirectorschoolWorker);
                school.SchoolWorkers.Add(DirectorschoolWorker);


                var student1email = "afsanamcmanus@gmail.com";
                var student1roleName = "Student";
                var student1userprofile = new UserProfile
                {
                    FirstName = "Afsana",
                    LastName = "Mcmanus",
                    MiddleName = "Rae",
                    RegistrationDate = DateTime.Now,
                    Gender = "Non-binary",
                    BirthDate = DateTime.Now.AddYears(-16).AddDays(65)
                };
                var student1user = new DbUser
                {
                    Email = student1email,
                    UserName = student1email,
                    PhoneNumber = "+1 312-452-3307",
                    UserProfile = student1userprofile
                };
                _context.UserProfiles.Add(student1userprofile);
                result = userManager.CreateAsync(student1user, "Qwerty1-").Result;
                result = userManager.AddToRoleAsync(student1user, student1roleName).Result;
                _context.SaveChanges();
                var student1person = new Person { UserProfile = student1userprofile, IsActive = true };
                _context.Persons.Add(student1person);
                _context.SaveChanges();
                var student1 = new Student { Person = student1person, Marks = new List<Mark>(), Siblings = new List<Student>(), SchoolClassStudents = new List<SchoolClassStudent>(), StudentSubjects = new List<StudentSubject>(), SchoolStudents = new List<SchoolStudent>() };
                _context.Students.Add(student1);
                _context.SaveChanges();
                school.SchoolStudents.Add(new SchoolStudent { School = school, Student = student1 });

                var student2email = "edisonmcmanus@gmail.com";
                var student2roleName = "Student";
                var student2userprofile = new UserProfile
                {
                    FirstName = "Edison",
                    LastName = "Mcmanus",
                    MiddleName = "Catrin",
                    RegistrationDate = DateTime.Now,
                    Gender = "Male",
                    BirthDate = DateTime.Now.AddYears(-15).AddDays(82)
                };
                var student2user = new DbUser
                {
                    Email = student2email,
                    UserName = student2email,
                    PhoneNumber = "+1 423-871-7315",
                    UserProfile = student2userprofile
                };
                _context.UserProfiles.Add(student2userprofile);
                result = userManager.CreateAsync(student2user, "Qwerty1-").Result;
                result = userManager.AddToRoleAsync(student2user, student2roleName).Result;
                _context.SaveChanges();
                var student2person = new Person { UserProfile = student2userprofile, IsActive = true };
                _context.Persons.Add(student2person);
                _context.SaveChanges();
                var student2 = new Student { Person = student2person, Marks = new List<Mark>(), Siblings = new List<Student>(), SchoolClassStudents = new List<SchoolClassStudent>(), StudentSubjects = new List<StudentSubject>(), SchoolStudents = new List<SchoolStudent>() };
                student2.Siblings.Add(student1);
                student1.Siblings.Add(student2);
                _context.Students.Add(student2);
                _context.SaveChanges();
                school.SchoolStudents.Add(new SchoolStudent { School = school, Student = student2 });



                var Teacheremail = "inigopitt@gmail.com";
                var TeacherroleName = "Teacher";
                var Teacheruserprofile = new UserProfile
                {
                    FirstName = "Inigo",
                    LastName = "Pitt",
                    MiddleName = "Mahek",
                    RegistrationDate = DateTime.Now,
                    Gender = "Male",
                    BirthDate = DateTime.Now.AddYears(-30).AddDays(55)
                };
                var Teacheruser = new DbUser
                {
                    Email = Teacheremail,
                    UserName = Teacheremail,
                    PhoneNumber = "+44 7364 649415",
                    UserProfile = Teacheruserprofile
                };
                _context.UserProfiles.Add(Teacheruserprofile);
                result = userManager.CreateAsync(Teacheruser, "Qwerty1-").Result;
                result = userManager.AddToRoleAsync(Teacheruser, TeacherroleName).Result;
                result = userManager.AddToRoleAsync(Teacheruser, "SchoolWorker").Result;
                _context.SaveChanges();
                var Teacherperson = new Person { UserProfile = Teacheruserprofile, IsActive = true };
                _context.Persons.Add(Teacherperson);
                var teacher = new SchoolWorker { Person = Teacherperson, RoleDescription = "Math Teacher", Subjects = new List<Subject>(), IsDirector = false, IsClassTeacher = true };
                _context.SchoolWorkers.Add(teacher);
                school.SchoolWorkers.Add(teacher);

                var Parentemail = "randallwhitney@gmail.com";
                var ParentroleName = "Parent";
                var Parentuserprofile = new UserProfile
                {
                    FirstName = "Randall",
                    LastName = "Whitney",
                    MiddleName = "Stacy",
                    RegistrationDate = DateTime.Now,
                    Gender = "Male",
                    BirthDate = DateTime.Now.AddYears(-51).AddDays(69)

                };
                var Parentuser = new DbUser
                {
                    Email = Parentemail,
                    UserName = Parentemail,
                    PhoneNumber = "+44 7911 023315",
                    UserProfile = Parentuserprofile
                };
                _context.UserProfiles.Add(Parentuserprofile);
                result = userManager.CreateAsync(Parentuser, "Qwerty1-").Result;
                result = userManager.AddToRoleAsync(Parentuser, ParentroleName).Result;
                _context.SaveChanges();
                var parent = new Parent { Kids = new List<Student>(), UserProfile = Parentuserprofile };
                parent.Kids.Add(student1);
                parent.Kids.Add(student2);
                _context.Parents.Add(parent);

                var schoolClass = new SchoolClass { CreateDate = DateTime.Now, FinalDate = DateTime.Now.AddDays(365), IsActive = true, Name = "10B", SchoolClassStudents = new List<SchoolClassStudent>(), Subjects = new List<Subject>(), Teacher = teacher };
                _context.SchoolClasses.Add(schoolClass);
                _context.SaveChanges();
                school.Classes.Add(schoolClass);
                student1.SchoolClassStudents.Add(new SchoolClassStudent { SchoolClass = schoolClass, Student = student1 });
                student2.SchoolClassStudents.Add(new SchoolClassStudent { SchoolClass = schoolClass, Student = student2 });
                var subject = new Subject { SchoolClass = schoolClass, Description = "Second Half", Journals = new List<Journal>(), Lessons = new List<Lesson>(), Name = "Math", StudentSubjects = new List<StudentSubject>(), Teacher = teacher };
                _context.Subjects.Add(subject);
                _context.SaveChanges();
                subject.StudentSubjects.Add(new StudentSubject { Student = student1, Subject = subject });
                subject.StudentSubjects.Add(new StudentSubject { Student = student2, Subject = subject });


                var subject2 = new Subject { SchoolClass = schoolClass, Description = "Full Class", Journals = new List<Journal>(), Lessons = new List<Lesson>(), Name = "Geography", StudentSubjects = new List<StudentSubject>(), Teacher = DirectorschoolWorker };
                _context.Subjects.Add(subject2);
                _context.SaveChanges();
                subject2.StudentSubjects.Add(new StudentSubject { Student = student1, Subject = subject2 });
                subject2.StudentSubjects.Add(new StudentSubject { Student = student2, Subject = subject2 });

                var journal = new Journal { Subject = subject, Marks = new List<Mark>() };
                _context.Journals.Add(journal);
                _context.SaveChanges();
                var mark1 = new Mark { Description = "Classwork", Journal = journal, MarkType = MarkType.Current, Student = student1, Value = 12, TimeSet = DateTime.Now };
                var mark2 = new Mark { Description = "Stereometry", Journal = journal, MarkType = MarkType.Semester1, Student = student2, Value = 9, TimeSet = DateTime.Now.AddDays(-5) };
                _context.Marks.Add(mark1);
                _context.Marks.Add(mark2);
                _context.SaveChanges();
                journal.Marks.Add(mark1);
                journal.Marks.Add(mark2);
                subject.Journals.Add(journal);

                var journal2 = new Journal { Subject = subject2, Marks = new List<Mark>() };
                _context.Journals.Add(journal2);
                _context.SaveChanges();
                var mark3 = new Mark { Description = "Homework", Journal = journal2, MarkType = MarkType.Current, Student = student1, Value = 5, TimeSet = DateTime.Now.AddDays(-2) };
                var mark4 = new Mark { Description = "Asia", Journal = journal2, MarkType = MarkType.Semester1, Student = student2, Value = 8, TimeSet = DateTime.Now.AddDays(-10) };
                _context.Marks.Add(mark3);
                _context.Marks.Add(mark4);
                _context.SaveChanges();
                journal2.Marks.Add(mark3);
                journal2.Marks.Add(mark4);
                subject2.Journals.Add(journal2);

                teacher.Class = schoolClass;


                var schedule = new Schedule { Lessons = new List<Lesson>(), SchoolClass = schoolClass };
                var lesson1 = new Lesson { Cabinet = "16", Homework = "p. 39 ex 1-4", Subject = subject, Theme = "Triangle", Time = "8:30", WeekDay = 5 };
                var lesson2 = new Lesson { Cabinet = "15", Homework = "Essay", Subject = subject, Theme = "Triangle", Time = "9:30", WeekDay = 4 };

                var lesson3 = new Lesson { Cabinet = "8", Homework = "Test", Subject = subject2, Theme = "Asia", Time = "12:25", WeekDay = 2 };
                var lesson4 = new Lesson { Cabinet = "15", Homework = "Essay", Subject = subject2, Theme = "Asia", Time = "13:50", WeekDay = 5 };
                _context.Schedules.Add(schedule);
                _context.Lessons.Add(lesson1);
                _context.Lessons.Add(lesson2);
                _context.Lessons.Add(lesson3);
                _context.Lessons.Add(lesson4);
                _context.SaveChanges();
                schedule.Lessons.Add(lesson1);
                schedule.Lessons.Add(lesson2);
                schedule.Lessons.Add(lesson3);
                schedule.Lessons.Add(lesson4);
                schoolClass.Schedules = new List<Schedule>();
                schoolClass.Schedules.Add(schedule);
                _context.SaveChanges();


                _context.SaveChanges();


            }
        }
        public static void SeedTables(EFDbContext _context)
        {

        }
        public static void SeedRoles(RoleManager<DbRole> roleManager)
        {

            var count = roleManager.Roles.Count();
            if (count <= 0)
            {
                var roleName = "User";
                var result = roleManager.CreateAsync(new DbRole
                {
                    Name = roleName
                }).Result;
                roleName = "Admin";
                result = roleManager.CreateAsync(new DbRole
                {
                    Name = roleName
                }).Result;
                roleName = "Student";
                result = roleManager.CreateAsync(new DbRole
                {
                    Name = roleName
                }).Result;
                roleName = "Parent";
                result = roleManager.CreateAsync(new DbRole
                {
                    Name = roleName
                }).Result;
                roleName = "Director";
                result = roleManager.CreateAsync(new DbRole
                {
                    Name = roleName
                }).Result;
                roleName = "Manager";
                result = roleManager.CreateAsync(new DbRole
                {
                    Name = roleName
                }).Result;
                roleName = "Teacher";
                result = roleManager.CreateAsync(new DbRole
                {
                    Name = roleName
                }).Result;
                roleName = "SchoolWorker";
                result = roleManager.CreateAsync(new DbRole
                {
                    Name = roleName
                }).Result;
            }
        }

        public static void SeedData(IServiceProvider services, IHostingEnvironment env, IConfiguration config)
        {
            using (var scope = services.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {

                var manager = scope.ServiceProvider.GetRequiredService<UserManager<DbUser>>();
                var managerRole = scope.ServiceProvider.GetRequiredService<RoleManager<DbRole>>();
                var context = scope.ServiceProvider.GetRequiredService<EFDbContext>();
                //var emailSender = scope.ServiceProvider.GetRequiredService<IEmailSender>();


                //SeederDB.SeedRegions(context);
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
                SeederDB.SeedRoles(managerRole);
                SeederDB.SeedUsers(manager, context);
                //SeederDB.SeedTables(context);
            }
        }


    }
}

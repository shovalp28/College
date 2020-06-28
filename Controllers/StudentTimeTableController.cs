using College.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace College.Controllers
{
    public class StudentTimeTableController : Controller
    {
        // GET: StudentTimeTable
        public ActionResult StudentLessonList(string id)
        {
            Student student = new Student();
            student.fromDate = DateTime.Now;
            student.id = id;
            student.toDate = DateTime.Now.AddDays(7);
            CollegeWS.College WS = new CollegeWS.College();
            var sesId = utils.GetSesId();
            student.StudentLessons = WS.GetStudentsTimeTable(sesId, student.id, student.fromDate, student.toDate);
            student.name = WS.GetStudentsName(sesId, student.id);
            student.logoLink = WS.GetCollegeLogo(sesId);


            return View("StudentLessonList", student);
        }

        public ActionResult StudentLessonListPartial(string fromDate, string toDate, string id)
        {
            Student student = new Student();
            student.id = id;

            
            if (IsValidDate(fromDate))
            {
                student.fromDate= Convert.ToDateTime(fromDate); 
            }

            if (IsValidDate(toDate))
            {
                student.toDate = Convert.ToDateTime(toDate);
            }


            CollegeWS.College WS = new CollegeWS.College();
            var sesId = utils.GetSesId();

            student.name = WS.GetStudentsName(sesId, student.id);
            student.logoLink = WS.GetCollegeLogo(sesId);



            student.StudentLessons = WS.GetStudentsTimeTable(sesId, student.id, student.fromDate, student.toDate);

            return PartialView("_StudentLessonListPartial", student);
        }

        protected bool IsValidDate(String date)

        {

            try

            {

                DateTime dt = DateTime.Parse(date);

                return true;

            }
            catch

            {

                return false;

            }

        }
    }
}
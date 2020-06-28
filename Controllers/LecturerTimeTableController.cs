using College.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace College.Controllers
{
    public class LecturerTimeTableController : Controller
    {

        public ActionResult LecturerHealthStatement(string id)
        {
            Lecturer lecturer = new Lecturer();
            lecturer.fromDate = DateTime.Now;

            lecturer.id = id;
            lecturer.toDate = DateTime.Now.AddDays(7);
            CollegeWS.College WS = new CollegeWS.College();
            var sesId = utils.GetSesId();
            bool lecturerHasHealthStatement = WS.LecturerHasHealthStatement(sesId, lecturer.id, DateTime.Now);

            if (lecturerHasHealthStatement)
                return JavaScript("window.alert('. הצהרת בריאות עבור יום נוכחי כבר נחתמה.אין צורך בחתימה נוספת');");

            lecturer.name = WS.GetLecturerName(sesId, lecturer.id);
            lecturer.logoLink = WS.GetCollegeLogo(sesId);
            lecturer.approveHealthStatmentId = false;

            return View("LecturerHealthStatement", lecturer);
        }
        public ActionResult SaveApproveHealthStatment(string id)
        {
            Lecturer lecturer = new Lecturer();
            lecturer.fromDate = DateTime.Now;

            lecturer.id = id;
            lecturer.toDate = DateTime.Now.AddDays(7);
            CollegeWS.College WS = new CollegeWS.College();
            var sesId = utils.GetSesId();

            WS.SaveLecturerHealthStatement(sesId, lecturer.id, DateTime.Now);


            return View("LecturerHealthStatement", lecturer);
        }
        public ActionResult OpenLecturerHealthStatement(string id)
        {
            Lecturer lecturer = new Lecturer();
            lecturer.fromDate = DateTime.Now;

            lecturer.id = id;
            lecturer.toDate = DateTime.Now.AddDays(7);
            CollegeWS.College WS = new CollegeWS.College();
            var sesId = utils.GetSesId();
            bool lecturerHasHealthStatement = WS.LecturerHasHealthStatement(sesId, lecturer.id, DateTime.Now);

            lecturer.name = WS.GetLecturerName(sesId, lecturer.id);
            lecturer.logoLink = WS.GetCollegeLogo(sesId);


            return RedirectToAction ("LecturerHealthStatement", lecturer);
        }

        public ActionResult OpenStudentInLesson(string courseNo, string lessonNo, string lessonDate)
        {
            Lecturer lecturer = new Lecturer();
            lecturer.fromDate = DateTime.Now;

            //lecturer.id = id;
            lecturer.toDate = DateTime.Now.AddDays(7);
            CollegeWS.College WS = new CollegeWS.College();
            var sesId = utils.GetSesId();

            DateTime lessonDateDt=DateTime.Now;
            if (IsValidDate(lessonDate))
            {
                lessonDateDt = Convert.ToDateTime(lessonDate);
            }

            lecturer.studentInLesson = WS.GetStudentsInLesson(sesId, courseNo,Convert.ToInt32( lessonNo), lessonDateDt);

            lecturer.name = WS.GetLecturerName(sesId, lecturer.id);
            lecturer.logoLink = WS.GetCollegeLogo(sesId);


            return RedirectToAction("StudentsInLessonList", lecturer);
        }

        

        public ActionResult LecturerLessonList(string id)
        {
            Lecturer lecturer = new Lecturer();
            lecturer.fromDate = DateTime.Now;

            lecturer.id = id;
            lecturer.toDate = DateTime.Now.AddDays(7);
            CollegeWS.College WS = new CollegeWS.College();
            var sesId = utils.GetSesId();
            lecturer.lecturerLessons = WS.GetLecturerTimeTable(sesId, lecturer.id, lecturer.fromDate, lecturer.toDate);
            lecturer.name = WS.GetLecturerName(sesId, lecturer.id);
            lecturer.logoLink = WS.GetCollegeLogo(sesId);


            return View("LecturerLessonList", lecturer);
        }

        public ActionResult LecturerLessonListPartial(string fromDate, string toDate, string id)
        {
            Lecturer lecturer = new Lecturer();
            lecturer.id = id;

            
            if (IsValidDate(fromDate))
            {
                lecturer.fromDate= Convert.ToDateTime(fromDate); 
            }

            if (IsValidDate(toDate))
            {
                lecturer.toDate = Convert.ToDateTime(toDate);
            }


            CollegeWS.College WS = new CollegeWS.College();
            var sesId = utils.GetSesId();

            lecturer.name = WS.GetLecturerName(sesId, lecturer.id);
            lecturer.logoLink = WS.GetCollegeLogo(sesId);


            lecturer.lecturerLessons = WS.GetLecturerTimeTable(sesId, lecturer.id, lecturer.fromDate, lecturer.toDate);

            return PartialView("_LecturerLessonListPartial", lecturer);
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
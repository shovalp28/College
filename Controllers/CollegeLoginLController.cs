using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using College.Models;

namespace College.Controllers
{
    public class CollegeLoginLController : Controller
    {
        public static Hashtable _validationCodesHashTable = new Hashtable();
        // GET: CollegeLoginS
        public ActionResult OpenLecturesLoginPage()
        {
            CollegeWS.College WS = new CollegeWS.College();
            var sesId = utils.GetSesId();

            var picture = WS.GetCollegeLogo(sesId);

            LogInScreenData logInScreenData = new LogInScreenData();
            logInScreenData.logoLink = picture;

            return View("CollegeLoginL", logInScreenData);
        }
        public ActionResult OpenLecturerValidationPage(string id)
        {
            CollegeWS.College WS = new CollegeWS.College();
            var sesId = utils.GetSesId();

            var picture = WS.GetCollegeLogo(sesId);

            LogInScreenData logInScreenData = new LogInScreenData();
            logInScreenData.logoLink = picture;
            logInScreenData.id = id;
            logInScreenData.mobileValidationCode = _validationCodesHashTable[id].ToString();
            return View("CollegeLoginLVald", logInScreenData);
        }
        public ActionResult BtnValidationloginClicked(string inputVcode, string mobileValidationCode, string id)
        {
            if (inputVcode != mobileValidationCode)
                return JavaScript("window.alert('. קוד אימות אינו נכון. אנא הזן קוד אימות שנית');");
            CollegeWS.College WS = new CollegeWS.College();
            var sesId = utils.GetSesId();

            var picture = WS.GetCollegeLogo(sesId);

            LogInScreenData logInScreenData = new LogInScreenData();
            logInScreenData.logoLink = picture;

            return RedirectToAction("LecturerLessonList", "LecturerTimeTable", new { id = id });
        }


        public ActionResult BtnloginClicked(string id)
        {
            CollegeWS.College WS = new CollegeWS.College();
            var sesId = utils.GetSesId();

            //WS.getstudentcom

            if (!WS.ValidIdNumber(id))
            {
                return JavaScript("window.alert('.  תעודת זהות שהוזנה אינה במבנה תקין. אנא הזן שנית');");
            }
            if (WS.LecturerIdNumberExist(sesId, id))
            {
                if (string.IsNullOrEmpty(WS.GetLecturerMobileById(sesId, id)))
                {
                    return JavaScript("window.alert('. לא הוגדר טלפון נייד ברטיס שלך, יש לפנות למכללה לטיפול');");
                }

                // return RedirectToAction("OpenStudentsLoginValidationPage", "CollegeLoginS");

                var picture = WS.GetCollegeLogo(sesId);

                LogInScreenData logInScreenData = new LogInScreenData();
                logInScreenData.logoLink = picture;

                Random rnd = new Random();
                int code = 1000 + rnd.Next(8999);
                var mobileNumber = WS.GetLecturerMobileById(sesId, id);

                #if DEBUG
                                mobileNumber = "0528692703";
                #endif

                WS.Send_Sms_msg(sesId, mobileNumber, "קוד האימות שלך הוא: " + code.ToString());
                logInScreenData.mobileValidationCode = code.ToString();


                if (_validationCodesHashTable.ContainsKey(id))
                {
                    _validationCodesHashTable[id] = code.ToString();

                }
                else
                {
                    _validationCodesHashTable.Add(id, code.ToString());

                }

                logInScreenData.id = id;

                //return PartialView("CollegeLoginSPartial", logInScreenData);

                return RedirectToAction("OpenLecturerValidationPage", "CollegeLoginL", new { id = id }); // redirects to internal url


            }
            else
            {
                return JavaScript("window.alert('. יש לפנות למכללה. תעודת זהות לא מופיעה במערכת');");
            }

        }

    }
}
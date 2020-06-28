using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace College.Models
{
    public class Lecturer
    {

        public string logoLink { get; set; }
        public string id { get; set; }
        public string name { get; set; }

        public DateTime fromDate { get; set; }

        public DateTime toDate { get; set; }

        public CollegeWS.LecturerLessons [] lecturerLessons { get; set; }

        public CollegeWS.StudentInLesson[] studentInLesson { get; set; }

        public bool approveHealthStatmentId { get; set; }

    }
}
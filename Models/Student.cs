using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace College.Models
{
    public class Student
    {

        public string logoLink { get; set; }
        public string id { get; set; }
        public string name { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/mm/yyyy}")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "אנא הכנס תאריך לידה בפורמט של dd/mm/yyyy")]
        public DateTime fromDate { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/mm/yyyy}")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "אנא הכנס תאריך לידה בפורמט של dd/mm/yyyy")]
        public DateTime toDate { get; set; }

        public CollegeWS.StudentLessons [] StudentLessons { get; set; }



    }
}
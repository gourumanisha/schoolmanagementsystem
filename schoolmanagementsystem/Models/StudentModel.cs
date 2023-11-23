using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace schoolmanagementsystem.Models
{
    public class StudentModel
    {
        public int StudentID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        //[DisplayFormat(ApplyFormatInEditMode = true,DataFormatString = "{0:yyyy-MM-dd HH:MI:SS")]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }
        public int ClassID { get; set; }
        public int SubjectID { get; set; }
    }
}
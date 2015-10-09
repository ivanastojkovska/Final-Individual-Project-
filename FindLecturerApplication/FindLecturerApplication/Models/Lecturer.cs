using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FindLecturerApplication.Models
{
    public class Lecturer 
    {
        [Key]
        public int VideoID { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }
        [Required]
        public virtual ICollection<Field> Fields { get; set; }
        [Required]
        public virtual ICollection<Course> Courses { get; set; }
        [Required]
        public string FormalEducation { get; set; }
        [Required]
        public string ProfesionalExperience { get; set; }
        public string Skills { get; set; }
        public Schedule Schedule { get; set; }
        public string UserImage { get; set; }
       
    }
}  

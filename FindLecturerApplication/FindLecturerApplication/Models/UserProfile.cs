using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FindLecturerApplication.Models
{
    public class UserProfile
    {
        [Key]
        public int ProfileID { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }
        public virtual Course Course { get; set; }

        public virtual Field Field { get; set; }

        public string FormalEducation { get; set; }
        [Required]
        public string ProfesionalExperience { get; set; }
        public string Skills { get; set; }
        public Schedule Schedule { get; set; }
        public string UserImage { get; set; }
       
    }
}
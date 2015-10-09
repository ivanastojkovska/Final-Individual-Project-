using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FindLecturerApplication.Models
{
    public class User
    {
        [Key]
        public int ID { get; set; }
        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Required]
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "Email doesn't look like a valid email address.")]
        public string Email { get; set; }
        [Required]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateRegistered { get; set; }

        public string Roles { get; set; }
        public User()
        {
            this.Roles = "";
            this.DateRegistered = DateTime.Now;
            this.isApproved = checked(true);
        }
        [DefaultValue(false)]
        public bool isApproved { get; set; }


        public virtual ICollection<BlogPost> Blogs { get; set; }
       
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
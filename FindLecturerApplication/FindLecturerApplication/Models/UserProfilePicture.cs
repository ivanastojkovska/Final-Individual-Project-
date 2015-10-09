using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FindLecturerApplication.Models
{
    public class UserProfilePicture
    {
        public int ID { get; set; }

        public string ImageUrl { get; set; }

        public virtual User User { get; set; }
    }
}
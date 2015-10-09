using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FindLecturerApplication.Models
{
    public class Field
    {
        public int FieldID { get; set; }

        public string Title { get; set; }
        public ICollection<Course> Courses { get; set; }
    }
}
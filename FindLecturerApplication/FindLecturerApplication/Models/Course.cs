﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FindLecturerApplication.Models
{
    public class Course
    {
        public int CourseID { get; set; }

        public int FieldID { get; set; }
        public string Title { get; set; }
        public virtual Field Field { get; set; }
    }
}
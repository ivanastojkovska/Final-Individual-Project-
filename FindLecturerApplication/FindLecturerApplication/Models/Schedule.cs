using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FindLecturerApplication.Models
{
    public class Schedule
    {
        public int id { get; set; }
        public String text { get; set; }
        public int start_time { get; set; }
        public int end_time { get; set; }
    }
}
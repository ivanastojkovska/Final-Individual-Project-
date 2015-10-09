using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FindLecturerApplication.Models
{
    public class BlogPost
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string Title { get; set; }
        public string Intro { get; set; }
        [Required]
        public string Content { get; set; }
        public string Tags { get; set; }
        [DataType(DataType.Date)]
        public DateTime DateCreated { get; set; }
        [DataType(DataType.Date)]
        public DateTime DateModified { get; set; }
        [DefaultValue(true)]
        public bool IsPublished { get; set; }
        public BlogPost()
        {
            this.IsPublished = true;
        }
    }
}
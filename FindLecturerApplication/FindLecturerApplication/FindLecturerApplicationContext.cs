using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

public class FindLecturerApplicationContext : DbContext
{
    // You can add custom code to this file. Changes will not be overwritten.
    // 
    // If you want Entity Framework to drop and regenerate your database
    // automatically whenever you change your model schema, please use data migrations.
    // For more information refer to the documentation:
    // http://msdn.microsoft.com/en-us/data/jj591621.aspx

    public FindLecturerApplicationContext() : base("name=FindLecturerApplicationContext")
    {
    }

    public System.Data.Entity.DbSet<FindLecturerApplication.Models.User> Users { get; set; }

   

    public System.Data.Entity.DbSet<FindLecturerApplication.Models.Field> Fields { get; set; }

    public System.Data.Entity.DbSet<FindLecturerApplication.Models.Course> Courses { get; set; }

    public System.Data.Entity.DbSet<FindLecturerApplication.Models.BlogPost> BlogPosts { get; set; }

    public System.Data.Entity.DbSet<FindLecturerApplication.Models.UserProfile> UserProfiles { get; set; }
}

using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace VideoTutorials.Models
{
    public class VideoTutorialsDbContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public VideoTutorialsDbContext() : base("name=VideoTutorialsDbContext")
        {
        }

        public System.Data.Entity.DbSet<VideoTutorials.Models.User> Users { get; set; }

        public System.Data.Entity.DbSet<VideoTutorials.Models.Category> Categories { get; set; }

        public System.Data.Entity.DbSet<VideoTutorials.Models.Video> Videos { get; set; }

    
    }
}

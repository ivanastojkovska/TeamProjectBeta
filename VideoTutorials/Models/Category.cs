using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VideoTutorials.Models
{
    public class Category
    {
        [Key]
        public int CategoryID { get; set; }
        [Display(Name = "Category Name")]
        public string Name { get; set; }
        [Display(Name = "Describe the category")]
        public string CategoryDescription { get; set; }
        public virtual ICollection<Video> Videos { get; set; }
    }
}
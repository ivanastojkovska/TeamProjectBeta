using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VideoTutorials.Models
{
    public class City
    {
        [Key]
        public int CityID { get; set; }
        [Display(Name = "City Name")]
        public string Name { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
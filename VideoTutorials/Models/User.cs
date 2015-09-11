using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VideoTutorials.Models
{
    public class User
    {
        [Key]
        public int UserID { get; set; }
        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Required]
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public DateTime DateRegistered { get; set; }
        public string Roles { get; set; }
        public User()
        {
            this.Roles = "";
        }
        public virtual ICollection<Video> Videos { get; set; }

        [Display(Name = "Date of birth")]
        [DataType(DataType.DateTime)]
        public DateTime? DateOfBirth { get; set; }
        public string FormalEducation { get; set; }
        public string Courses { get; set; }
        public string ProfesionalExperience { get; set; }
        public string Skills { get; set; }
      
    }
}
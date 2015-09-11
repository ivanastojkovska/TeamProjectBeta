using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace VideoTutorials.Models
{
    public class Video
    {
        [Key]
        public int VideoID { get; set; }
        [Required]
        [Display(Name = "Title")]
        public string Title { get; set; }
        [Required]
        [Display(Name = "Description")]
        public string Description { get; set; }
        [AllowHtml]
        [Display(Name = "Embeded Link")]
        public string Link { get; set; }
        public string Tags { get; set; }
        public string Thumbnail { get; set; }
        public int CategoryID { get; set; }
        public virtual Category Categories { get; set; }
        public bool isApproved { get; set; }
    }
}
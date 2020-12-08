using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FTATeam_ASPNetMVC5.Dtos
{
    public class TeamImageDto
    {
        public int Id { get; set; }

        [Required]
        public string Path { get; set; }

        [Required]
        [Display(Name ="Date Posted")]
        public DateTime DatePosted { get; set; }

        [Required]
        public HttpPostedFileBase File { get; set; }

    }
}
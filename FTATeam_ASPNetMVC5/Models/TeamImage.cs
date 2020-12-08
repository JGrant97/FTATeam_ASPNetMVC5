using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FTATeam_ASPNetMVC5.Models
{
    public class TeamImage
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Date Posted")]
        public DateTime DatePosted { get; set; }

        [Required]
        public byte[] File { get; set; }
    }
}
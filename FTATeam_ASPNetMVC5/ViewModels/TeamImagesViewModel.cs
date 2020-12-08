using FTATeam_ASPNetMVC5.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FTATeam_ASPNetMVC5.ViewModels
{
    public class TeamImagesViewModel
    {
        public TeamImage TeamImage { get; set; }

        [Required]
        [Display(Name = "Upload File")]
        public HttpPostedFileBase File { get; set; }
    }
}
using FTATeam_ASPNetMVC5.Dtos;
using FTATeam_ASPNetMVC5.Models;
using FTATeam_ASPNetMVC5.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FTATeam_ASPNetMVC5.Controllers
{
    public class TeamImagesController : Controller
    {
        private ApplicationDbContext _context;

        public TeamImagesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: TeamImage
        public ActionResult Index()
        {
            var images = _context.Images.ToList();

            if (User.IsInRole(RoleName.CanManageImages))
                return View("ImageList", images);

            return View("ReadOnlyImageList", images);
        }

        [Authorize(Roles = RoleName.CanManageImages)]
        public ActionResult New()
        {
            var viewModel = new TeamImagesViewModel()
            {
                TeamImage = new TeamImage()
            };

            return View("ImageForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = RoleName.CanManageImages)]


        //Uploads file to db as a byte array
        public ActionResult Upload(TeamImagesViewModel teamImageViewModel)
        {
            string extension = Path.GetExtension(teamImageViewModel.File.FileName);
            var formats = new string[] { ".jpg", ".png", ".jpeg" };

            if (teamImageViewModel.TeamImage.Id == 0)
            {
                if (teamImageViewModel.File.ContentLength > 0 && formats.Contains(extension))
                {
                    teamImageViewModel.TeamImage.DatePosted = DateTime.Now;
                    teamImageViewModel.TeamImage.File = new byte[teamImageViewModel.File.InputStream.Length];
                    teamImageViewModel.File.InputStream.Read(teamImageViewModel.TeamImage.File, 0, teamImageViewModel.TeamImage.File.Length);

                    _context.Images.Add(teamImageViewModel.TeamImage);

                }
                else
                {
                    throw new InvalidOperationException("Inavlid file format");
                }
            }
            else
            {
                if (teamImageViewModel.File.ContentLength > 0 && formats.Contains(extension))
                {
                    var currentImage = _context.Images.SingleOrDefault(i => i.Id == teamImageViewModel.TeamImage.Id);
                    currentImage.DatePosted = DateTime.Now;
                    currentImage.File = new byte[teamImageViewModel.File.InputStream.Length];
                    teamImageViewModel.File.InputStream.Read(currentImage.File, 0, currentImage.File.Length);
                }
                else
                {
                    throw new InvalidOperationException("Inavlid file format");
                }
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "TeamImages");
        }

        [Authorize(Roles = RoleName.CanManageImages)]
        public ActionResult Edit(int id)
        {
            var teamImage = _context.Images.SingleOrDefault(i => i.Id == id);

            if (teamImage == null)
                return HttpNotFound();

            var viewmodel = new TeamImagesViewModel()
            {
                TeamImage = teamImage
            };

            return View("ImageForm", viewmodel);
        }
    }
}
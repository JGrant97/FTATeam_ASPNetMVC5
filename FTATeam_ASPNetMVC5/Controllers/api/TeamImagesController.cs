using AutoMapper;
using FTATeam_ASPNetMVC5.Dtos;
using FTATeam_ASPNetMVC5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FTATeam_ASPNetMVC5.Controllers.api
{
    public class TeamImagesController : ApiController
    {
        private ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public TeamImagesController()
        {
            _context = new ApplicationDbContext();

            var config = new MapperConfiguration(x =>
            {
                x.CreateMap<TeamImage, TeamImageDto>();
                x.CreateMap<TeamImageDto, TeamImage>()
                    .ForMember(i => i.Id, opt => opt.Ignore());
            });

            _mapper = config.CreateMapper();
        }

        //GET /api/teamimages
        public IHttpActionResult GetImages()
        {
            var images = _context.Images
                .ToList();

            return Ok(images);
        }

        //GET /api/teamimages/1
        public IHttpActionResult GetImage(int id)
        {
            var image = _context.Images.SingleOrDefault(i => i.Id == id);

            if (image == null)
                return NotFound();

            return Ok(image);
        }

        //Post /api/teamimages
        [HttpPost]
        public IHttpActionResult UploadImage(TeamImageDto teamImageDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var image = _mapper.Map<TeamImageDto, TeamImage>(teamImageDto);

            _context.Images.Add(image);
            _context.SaveChanges();

            teamImageDto.Id = image.Id;

            return Created(new Uri(Request.RequestUri + "/"), teamImageDto);
        }

        //DELETE /api/images/1
        public void DeleteImage(int id)
        {
            var imageInDb = _context.Images.SingleOrDefault(i => i.Id == id);

            if (imageInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.Images.Remove(imageInDb);
            _context.SaveChanges();
        }
    }
}

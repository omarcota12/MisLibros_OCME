using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MisLibros_OCME.Data.Models;
using MisLibros_OCME.Data.services;
using MisLibros_OCME.Data.ViewModels;

namespace MisLibros_OCME.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublisherController : ControllerBase
    {
        private PublishersService _publisherServices;
        public PublisherController(PublishersService publisherservice)
        {
            _publisherServices = publisherservice;

        }
        [HttpPost("add-publisher")]
        public IActionResult AddPublisher([FromBody] PublisherVM publisher)
        {
            _publisherServices.AddPublisher(publisher);
            return Ok();
        }
    }
}

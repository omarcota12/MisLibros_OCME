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

        [HttpGet("get-publisher-books-with-authors/{id}")]
        public IActionResult GetPublisherData(int id) 
        {
            var _response = _publisherServices.GetPublisherData(id);
                return Ok(_response);
        }

        [HttpDelete("delete-publisher-by-id/{id}")]
        public IActionResult DeletePublisherById(int id)
        {
            _publisherServices.DeletePublisherById(id);
            return Ok();
        }
    }
}

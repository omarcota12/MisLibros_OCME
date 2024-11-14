using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MisLibros_OCME.Data.Models;
using MisLibros_OCME.Data.services;
using MisLibros_OCME.Data.ViewModels;

namespace MisLibros_OCME.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private Authorservice _authorsServices;
        public AuthorsController(Authorservice authorservice)
        {
            _authorsServices = authorservice;

        }
        [HttpPost("add-author")]
        public IActionResult AddAuthor([FromBody] AuthorVM author) 
        {
            _authorsServices.AddAuthor(author);
            return Ok();
        }
    }
}

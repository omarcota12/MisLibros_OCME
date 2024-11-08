using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MisLibros_OCME.Data.services;
using MisLibros_OCME.Data.ViewModels;

namespace MisLibros_OCME.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class bookscontrollerr : ControllerBase
    {
        public bookservice _bookservice;

        public bookscontrollerr(bookservice bookservice)
        {
            _bookservice = bookservice;
        }

        [HttpPost("add-book")]
        public IActionResult Addbook([FromBody]bookVM book)
        {
            _bookservice.AddBook(book);
            return Ok();
        }
    }
}

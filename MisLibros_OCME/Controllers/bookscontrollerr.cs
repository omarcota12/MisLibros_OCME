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
        [HttpGet("get-all-books")]
        public IActionResult GetAllBooks()
        {
            var allbooks = _bookservice.GetAllBks();
            return Ok(allbooks);
        }

        [HttpGet("get-book-by-id/{id}")]
        public IActionResult GetBookById(int id)
        {
            var book = _bookservice.GetBookByID(id);
            return Ok(book);
        }

        [HttpPost("add-book")]
        public IActionResult Addbook([FromBody] bookVM book)
        {
            _bookservice.AddBook(book);
            return Ok();
        }

        [HttpPut("update-book-by-id/{id}")]
        public IActionResult UpdateBookById(int id, [FromBody] bookVM book)
        {
            var updateBook = _bookservice.UpdateBookByID(id, book);
            return Ok(updateBook);
        }

        [HttpDelete("delete-book-by-id/{id}")]
        public IActionResult DeleteBookById(int id)
        {
           _bookservice.DeletebookById(id);
           return Ok();
        }
    }
}



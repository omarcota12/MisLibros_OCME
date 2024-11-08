using MisLibros_OCME.Data.ViewModels;
using MisLibros_OCME.Data.Models;
using System;

namespace MisLibros_OCME.Data.services
{
    public class bookservice
    {
        private AppDbcontext _context;
        public bookservice(AppDbcontext context)
        {
            _context = context;

        }

        public void AddBook(bookVM book)
        {
            var _book = new Book()
            {
                Titulo = book.Titulo,
                Descripcion = book.Descripcion,
                IsRead = book.IsRead,
                DateRead = book.DateRead,
                Rate = book.Rate,
                Genero = book.Genero,
                Autor = book.Autor,
                CoverUrl = book.CoverUrl,
                DateAdded = DateTime.Now

            };
            _context.Books.Add(_book);
            _context.SaveChanges();

        }

    
    }
}

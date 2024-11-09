using MisLibros_OCME.Data.ViewModels;
using MisLibros_OCME.Data.Models;
using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;

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
        public List<Book> GetAllBks() => _context.Books.ToList();
        public Book GetBookByID(int bookid) => _context.Books.FirstOrDefault(n => n.id == bookid);

        public Book UpdateBookByID(int bookid, bookVM book)
        {
            var _book = _context.Books.FirstOrDefault(n =>n.id == bookid);
            if(_book !=null )
            {
                _book.Titulo = book.Titulo;
                _book.Descripcion = book.Descripcion;
                _book.IsRead = book.IsRead;
                _book.DateRead = book.DateRead;
                _book.Rate = book.Rate;
                _book.Genero = book.Genero;
                _book.Autor = book.Autor;
                _book.CoverUrl = book.CoverUrl;

                _context.SaveChanges();

            }
            return _book;
        }
        public void DeletebookById(int bookid)
        {
            var _book = _context.Books.FirstOrDefault(n => n.id == bookid);
            if(_book != null )
            {
                _context.Books.Remove( _book );
                _context.SaveChanges();
            }
        }

    }
}

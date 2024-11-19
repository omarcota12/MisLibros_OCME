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

        public void AddBookwithAuthors(bookVM book)
        {
            var _book = new Book()
            {
                Titulo = book.Titulo,
                Descripcion = book.Descripcion,
                IsRead = book.IsRead,
                DateRead = book.DateRead,
                Rate = book.Rate,
                Genero = book.Genero,               
                CoverUrl = book.CoverUrl,
                DateAdded = DateTime.Now,
                PublisherId = book.PublisherID

            };
            _context.Books.Add(_book);
            _context.SaveChanges();

            foreach (var id in book.AutorIDs)
            {
                var _book_author = new Book_Authos()
                {
                    BookId = _book.Id,
                    AuthorId = id
                };
                _context.Book_Authors.Add(_book_author);
                _context.SaveChanges();

            }
        }
        public List<Book> GetAllBks() => _context.Books.ToList();
        public BookWithAuthorsVM GetBookByID(int bookid)
        {
            var _bookWithAuthors = _context.Books.Where(n => n.Id == bookid).Select(Book => new BookWithAuthorsVM()
            {
                Titulo = Book.Titulo,
                Descripcion = Book.Descripcion,
                IsRead = Book.IsRead,
                DateRead = Book.DateRead,
                Rate = Book.Rate,
                Genero = Book.Genero,
                CoverUrl = Book.CoverUrl,
                PublisherName = Book.Publisher.Name,
                AuthorNames = Book.Book_Authors.Select(n => n.Author.Name).ToList()
            }).FirstOrDefault();
            return _bookWithAuthors;
        }

        public Book UpdateBookByID(int bookid, bookVM book)
        {
            var _book = _context.Books.FirstOrDefault(n =>n.Id == bookid);
            if(_book !=null )
            {
                _book.Titulo = book.Titulo;
                _book.Descripcion = book.Descripcion;
                _book.IsRead = book.IsRead;
                _book.DateRead = book.DateRead;
                _book.Rate = book.Rate;
                _book.Genero = book.Genero;
                _book.CoverUrl = book.CoverUrl;

                _context.SaveChanges();

            }
            return _book;
        }
        public void DeletebookById(int bookid)
        {
            var _book = _context.Books.FirstOrDefault(n => n.Id == bookid);
            if(_book != null )
            {
                _context.Books.Remove( _book );
                _context.SaveChanges();
            }
        }

    }
}

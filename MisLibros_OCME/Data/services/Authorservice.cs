using MisLibros_OCME.Data.Models;
using MisLibros_OCME.Data.ViewModels;
using System.Linq;

namespace MisLibros_OCME.Data.services
{
    public class Authorservice
    {

        private AppDbcontext _context;
        public Authorservice(AppDbcontext context)
        {
            _context = context;

        }

        public void AddAuthor(AuthorVM author)
        {
            var _author = new Author()
            {
                Name = author.FullName

            };
            _context.Authors.Add(_author);
            _context.SaveChanges();
        }

        public AuthorWithBookVM GetAuthorWithBooks(int authorId)
        {
            var _author = _context.Authors.Where(n => n.Id == authorId).Select(n => new AuthorWithBookVM()
            {
                Fullname = n.Name,
                BookTitles = n.Book_Authors.Select(n => n.Book.Titulo).ToList()
            }).FirstOrDefault();
            return _author;
        }
    }
}

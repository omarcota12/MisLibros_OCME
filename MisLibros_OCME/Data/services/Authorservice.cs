using MisLibros_OCME.Data.Models;
using MisLibros_OCME.Data.ViewModels;


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
    }
}

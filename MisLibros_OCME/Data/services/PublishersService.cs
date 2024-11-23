using MisLibros_OCME.Data.Models;
using MisLibros_OCME.Data.ViewModels;
using System;
using System.Linq;

namespace MisLibros_OCME.Data.services
{
    public class PublishersService
    {

        private AppDbcontext _context;
        public PublishersService(AppDbcontext context)
        {
            _context = context;

        }

        public Publisher AddPublisher(PublisherVM publisher)
        {
            var _publisher = new Publisher()
            {
                Name = publisher.Name

            };
            _context.Publishers.Add(_publisher);
            _context.SaveChanges();

            return _publisher;
        }

        public Publisher GetPublisherByID(int id) => _context.Publishers.FirstOrDefault(n => n.ID == id);

        public PublisherWithBooksAndAuthorsVM GetPublisherData(int publisherId)
        {
            var _publisherData = _context.Publishers.Where(n => n.ID == publisherId)
           .Select(n => new PublisherWithBooksAndAuthorsVM()
           {
               Name = n.Name,
               BookAuthors = n.Books.Select(n => new BookAuthorVM()
               {
                   BookName = n.Titulo,
                   BookAuthors = n.Book_Authors.Select(n => n.Author.Name).ToList()
               }).ToList()
           }).FirstOrDefault();
            return _publisherData;
        }

        public void DeletePublisherById(int id)
        {
            var _publisher = _context.Publishers.FirstOrDefault(n => n.ID == id);
            if (_publisher != null)
            {
                _context.Publishers.Remove(_publisher);
                _context.SaveChanges();
            }
            else
            {
                throw new Exception($"La editora con el id: {id} no existe");
            }
        }
    }
}

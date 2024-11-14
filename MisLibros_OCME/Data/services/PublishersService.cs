using MisLibros_OCME.Data.Models;
using MisLibros_OCME.Data.ViewModels;
using System;

namespace MisLibros_OCME.Data.services
{
    public class PublishersService
    {

        private AppDbcontext _context;
        public PublishersService(AppDbcontext context)
        {
            _context = context;

        }

        public void AddPublisher(PublisherVM publisher)
        {
            var _publisher = new Publisher()
            {
                Name = publisher.Name

            };
            _context.Publishers.Add(_publisher);
            _context.SaveChanges();
        }
    }
}

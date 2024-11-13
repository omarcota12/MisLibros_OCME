using System.Collections.Generic;

namespace MisLibros_OCME.Data.Models
{
    public class Author
    {
        public int Id { get; set; }
        public string Name { get; set; }
        //propiedades de navegacion

        public List<Book_Authos> Book_Authors { get; set; }
    }
}

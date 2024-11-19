using System.Collections.Generic;

namespace MisLibros_OCME.Data.ViewModels
{
    public class AuthorVM
    {
        public string FullName { get; set; }
    }
    public class AuthorWithBookVM
    {
        public string Fullname { get; set; }
        public List<string> BookTitles { get; set; }

    }
}

using System;
using System.Collections.Generic;

namespace MisLibros_OCME.Data.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public bool IsRead { get; set; }
        public DateTime DateRead { get; set; }
        public int? Rate { get; set; }
        public string Genero { get; set; }
        public string CoverUrl { get; set; }
        public DateTime DateAdded { get; set; }
        //propiedad de navegacion (en esta parte es donde "mapeamos")
        public int PublisherId { get; set; }
        public Publisher Publisher { get; set; }

        public List<Book_Authos> Book_Authors { get; set; }
    }
    public class BookWithAuthorsVM
    {
       
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public bool IsRead { get; set; }
        public DateTime DateRead { get; set; }
        public int? Rate { get; set; }
        public string Genero { get; set; }
        public string CoverUrl { get; set; }
        public string PublisherName { get; set; }
        public List<string> AuthorNames { get; set; }
    }
 }

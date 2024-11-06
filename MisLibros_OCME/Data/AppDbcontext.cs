
using Microsoft.EntityFrameworkCore;
using MisLibros_OCME.Data.Models;

namespace MisLibros_OCME.Data
{
    public class AppDbcontext : DbContext
    {
        public AppDbcontext(DbContextOptions<AppDbcontext> options) : base(options)
        {


        }
        public DbSet<Book> Books { get; set; }
    }
}

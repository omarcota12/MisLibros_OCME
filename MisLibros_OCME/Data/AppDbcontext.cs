
using Microsoft.EntityFrameworkCore;
using MisLibros_OCME.Data.Models;

namespace MisLibros_OCME.Data
{
    public class AppDbcontext : DbContext
    {
        public AppDbcontext(DbContextOptions<AppDbcontext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            modelBuilder.Entity<Book_Authos>()
                .HasOne(b => b.Book)
                .WithMany(ba => ba.Book_Authors)
                .HasForeignKey(bi => bi.BookId);

            modelBuilder.Entity<Book_Authos>()
               .HasOne(b => b.Author)
               .WithMany(ba => ba.Book_Authors)
               .HasForeignKey(bi => bi.AuthorId);

        }
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book_Authos> Book_Authors { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
    }
}

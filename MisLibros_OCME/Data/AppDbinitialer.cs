using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using MisLibros_OCME.Data.Models;
using System;
using System.Linq;

namespace MisLibros_OCME.Data
{
    public class AppDbinitialer
    {
        //metodo que agrega datos a nuestra BD

        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbcontext>();

                if (!context.Books.Any())
                {
                    context.Books.AddRange(new Book()

                    {
                        Titulo = "1st Book Title",
                        Descripcion = "1st Book Descripcion",
                        IsRead = true,
                        DateRead = DateTime.Now.AddDays(-10),
                        Rate = 4,
                        Genero = "biography",
                        CoverUrl = "https...",
                        DateAdded = DateTime.Now,
                    },
                    new Book()
                    {
                        Titulo = "2nd book Title",
                        Descripcion = "2nd book Description",
                        IsRead = true,
                        Rate = 4,
                        Genero = "biography",
                        CoverUrl = "https...",
                        DateAdded = DateTime.Now,

                    });
                    context.SaveChanges();

                    
                }

                  
            }

        }
    }
}

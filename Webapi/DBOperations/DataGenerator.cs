using System;
using Microsoft.EntityFrameworkCore;

namespace Webapi.DBOperations
{
    public class DataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new BookStoreDbContext(serviceProvider.GetRequiredService<DbContextOptions<BookStoreDbContext>>()))
            {
                if (context.Books.Any())
                {
                    return;
                }

                context.Books.AddRange(
                    new Book
                    {
                        GenreId = 1,
                        PageCount = 100,
                        PublishDate = new DateTime(2001, 6, 12),
                        Title = "Lean Startup"
                    },
                    new Book
                    {

                        GenreId = 2,
                        PageCount = 250,
                        PublishDate = new DateTime(2010, 5, 23),
                        Title = "Herland"
                    },
                    new Book
                    {
                        GenreId = 2,
                        PageCount = 150,
                        PublishDate = new DateTime(2005, 1, 13),
                        Title = "Dune"
                    });

                context.SaveChanges();
                
            }
        }
    }
}

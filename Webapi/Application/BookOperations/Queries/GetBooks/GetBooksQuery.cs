using System;
using Webapi.Common;
using Webapi.DBOperations;

namespace Webapi.Application.BookOperations.Queries
{
    public class GetBooksQuery
    {
        public readonly BookStoreDbContext _dbContext;
        public GetBooksQuery(BookStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<BooksViewModel> Handle()
        {
             var booklist=_dbContext.Books.OrderBy(x=>x.id).ToList<Book>();
             List<BooksViewModel> vm= new List<BooksViewModel>();
             foreach(var book in booklist)
             {
                vm.Add(new BooksViewModel(){
                    Title=book.Title,
                    PageCount=book.PageCount,
                    PublishDate=book.PublishDate.ToString("dd/MM,yyyy"),
                    Genre=((GenreEnum)book.GenreId).ToString()
                });
             }
            return vm;
        }
    }

    public class BooksViewModel
    {
        public string Title { get; set; }
        public int PageCount { get; set; }
        public string PublishDate { get; set; }
        public string Genre { get; set; }
    }
}

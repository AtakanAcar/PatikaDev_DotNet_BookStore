using System;
using Webapi.Common;
using Webapi.DBOperations;

namespace Webapi.Application.BookOperations.Queries.GetBookById
{
    public class GetBookByIdQuery
    {
        private readonly BookStoreDbContext _dbContext;
        public int id;
        public GetBookByIdQuery(BookStoreDbContext dbContext)
        {
            _dbContext=dbContext;   
        }

        public BookViewModel Handle()
        {
            var book=_dbContext.Books.Where(b=>b.id==id).SingleOrDefault();
            BookViewModel vm=new();
            vm.Title=book.Title;
            vm.PageCount=book.PageCount;
            vm.PublishDate=book.PublishDate.ToString("dd/MM/yyyy");
            vm.Genre=((GenreEnum)book.GenreId).ToString();
            return vm;
        }
    }

    public class BookViewModel
    {
        public string Title { get; set; }
        public int PageCount { get; set; }
        public string PublishDate { get; set; }
        public string Genre { get; set; }
    }
}

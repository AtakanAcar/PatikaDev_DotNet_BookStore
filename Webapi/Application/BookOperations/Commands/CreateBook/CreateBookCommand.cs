using System;
using Webapi.DBOperations;

namespace Webapi.Application.BookOperations.Commands.CreateBook
{
    public class CreateBookCommand
    {

        public CreateBookModel Model {get;set;}

        private readonly BookStoreDbContext _dbContext;
        public CreateBookCommand(BookStoreDbContext dbContext)
        {
            _dbContext=dbContext;   
        }

        public void Handle()
        {
            var book=_dbContext.Books.SingleOrDefault(b=>b.Title==Model.Title);
            if(book is not null){
                throw new InvalidOperationException("Kitap Mevcut");
            }

            book=new();
            book.Title=Model.Title;
            book.PublishDate=Model.PublishDate;
            book.PageCount=Model.PageCount;
            book.GenreId=Model.GenreID;

            _dbContext.Books.Add(book);
            _dbContext.SaveChanges();
        }

        public class CreateBookModel
        {
            public string Title { get; set; }
            public int GenreID { get; set; }
            public int PageCount { get; set; }
            public DateTime PublishDate { get; set; }
        }
    }
}

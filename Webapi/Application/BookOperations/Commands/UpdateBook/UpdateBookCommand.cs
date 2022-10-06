using System;
using Webapi.DBOperations;

namespace Webapi.Application.BookOperations.Commands.UpdateBook
{
    public class UpdateBookCommand
    {
        private readonly BookStoreDbContext _dbContext;
        public UpdateBookModel model;
        public int id;
        public UpdateBookCommand(BookStoreDbContext dbContext)
        {
            _dbContext=dbContext;
        }

        public void Handle()
        {
            var book=_dbContext.Books.SingleOrDefault(b=>b.id==id);
            if(book is null){
                throw new InvalidOperationException("Kitap Mevcut Değil");
            }
            
            book.GenreId=model.GenreId!=default? model.GenreId:book.GenreId;
            book.PageCount=model.PageCount!=default? model.PageCount:book.PageCount;
            book.PublishDate=model.PublishDate!=default? model.PublishDate:book.PublishDate;
            book.Title=model.Title!=default? model.Title:book.Title;
            _dbContext.SaveChanges();
        }
    }

    public class UpdateBookModel
        {
            public string Title { get; set; }
            public int GenreId { get; set; }
            public int PageCount { get; set; }
            public DateTime PublishDate { get; set; }
        }
}

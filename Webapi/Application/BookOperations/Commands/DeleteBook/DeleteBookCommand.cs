using System;
using Webapi.DBOperations;

namespace Webapi.Application.BookOperations.Commands.DeleteBook
{
    public class DeleteBookCommand
    {
        private readonly BookStoreDbContext _dbContext;
        public int bookId{get;set;}
        public DeleteBookCommand(BookStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        
        public void Handle()
        {
            var book=_dbContext.Books.SingleOrDefault(b=>b.id==bookId);
            if (book is null)
                throw new InvalidOperationException("Kitap Bulunamadı");

            _dbContext.Books.Remove(book);
            _dbContext.SaveChanges();
        }
    }
}

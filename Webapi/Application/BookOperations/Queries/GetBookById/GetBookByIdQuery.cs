using System;
using AutoMapper;
using Webapi.Common;
using Webapi.DBOperations;

namespace Webapi.Application.BookOperations.Queries.GetBookById
{
    public class GetBookByIdQuery
    {
        private readonly BookStoreDbContext _dbContext;
        private readonly IMapper _mapper;
        public int id;
        public GetBookByIdQuery(BookStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public BookViewModel Handle()
        {
            var book=_dbContext.Books.Where(b=>b.id==id).SingleOrDefault();
            if(book is null)
                throw new InvalidOperationException("Kitap Bulunamadı");
                
            BookViewModel vm=_mapper.Map<BookViewModel>(book);
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

using System;
using AutoMapper;
using Webapi.Common;
using Webapi.DBOperations;

namespace Webapi.Application.BookOperations.Queries
{
    public class GetBooksQuery
    {
        public readonly BookStoreDbContext _dbContext;
        private readonly IMapper _mapper;
        public GetBooksQuery(BookStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public List<BooksViewModel> Handle()
        {
             var booklist=_dbContext.Books.OrderBy(x=>x.id).ToList<Book>();
            List<BooksViewModel> vm= _mapper.Map<List<BooksViewModel>>(booklist);
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

using System;
using AutoMapper;
using Webapi.Application.BookOperations.Queries;
using Webapi.Application.BookOperations.Queries.GetBookById;
using static Webapi.Application.BookOperations.Commands.CreateBook.CreateBookCommand;

namespace Webapi.Common
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateBookModel,Book>();
            CreateMap<Book,BookViewModel>().ForMember(dest=>dest.Genre,opt=>opt.MapFrom(src=>((GenreEnum)src.GenreId).ToString()));
            CreateMap<Book,BooksViewModel>().ForMember(dest=>dest.Genre,opt=>opt.MapFrom(src=>((GenreEnum)src.GenreId).ToString()));
        }
    }
}

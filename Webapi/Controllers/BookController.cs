using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace Webapi.Controllers
{
    [ApiController]
    [Route("[controller]s")]
    public class BookController:ControllerBase
    {
        private static List<Book> BookList=new List<Book>(){
            new Book{
                id=1,
                GenreId=1,
                PageCount=100,
                PublishDate=new DateTime(2001,6,12),
                Title="Lean Startup"
            },
            new Book{
                id=2,
                GenreId=2,
                PageCount=250,
                PublishDate=new DateTime(2010,5,23),
                Title="Herland"
            },
            new Book{
                id=3,
                GenreId=2,
                PageCount=150,
                PublishDate=new DateTime(2005,1,13),
                Title="Dune"
            }
        };

        [HttpGet]
        public List<Book> GetBooks(){
            var booklist=BookList.OrderBy(x=>x.id).ToList<Book>();
            return booklist;
        }

        [HttpGet("{id}")]
        public Book GetById(int id){
            var book=BookList.Where(b=>b.id==id).SingleOrDefault();
            return book;
        }

        //[HttpGet("{id}")]
        //public Book Get([FromQuery] string id){
        //    var book=BookList.Where(b=>b.id==Convert.ToInt32(id)).SingleOrDefault();
        //    return book;
        //}

        [HttpPost]
        public IActionResult AddBook([FromBody] Book newBook){
            var book=BookList.SingleOrDefault(b=>b.Title==newBook.Title);
            if(book is not null){
                return BadRequest();
            }
            BookList.Add(newBook);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateBook(int id ,[FromBody] Book updatedBook){
            var book=BookList.SingleOrDefault(b=>b.id==id);
            if(book is null){
                return BadRequest();
            }
            book.GenreId=updatedBook.GenreId!=default? updatedBook.GenreId:book.GenreId;
            book.PageCount=updatedBook.PageCount!=default? updatedBook.PageCount:book.PageCount;
            book.PublishDate=updatedBook.PublishDate!=default? updatedBook.PublishDate:book.PublishDate;
            book.Title=updatedBook.Title!=default? updatedBook.Title:book.Title;
            return Ok();
        }

    }
}

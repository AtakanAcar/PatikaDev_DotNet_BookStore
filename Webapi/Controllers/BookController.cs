using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Webapi.DBOperations;

namespace Webapi.Controllers
{
    [ApiController]
    [Route("[controller]s")]
    public class BookController:ControllerBase
    {

        private readonly BookStoreDbContext _context;
        public BookController(BookStoreDbContext context)
        {
            _context=context;
        }

        
        [HttpGet]
        public List<Book> GetBooks(){
            var booklist=_context.Books.OrderBy(x=>x.id).ToList<Book>();
            return booklist;
        }

        [HttpGet("{id}")]
        public Book GetById(int id){
            var book=_context.Books.Where(b=>b.id==id).SingleOrDefault();
            return book;
        }

        //[HttpGet("{id}")]
        //public Book Get([FromQuery] string id){
        //    var book=BookList.Where(b=>b.id==Convert.ToInt32(id)).SingleOrDefault();
        //    return book;
        //}

        [HttpPost]
        public IActionResult AddBook([FromBody] Book newBook){
            var book=_context.Books.SingleOrDefault(b=>b.Title==newBook.Title);
            if(book is not null){
                return BadRequest();
            }
            _context.Books.Add(newBook);
            _context.SaveChanges();
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateBook(int id ,[FromBody] Book updatedBook){
            var book=_context.Books.SingleOrDefault(b=>b.id==id);
            if(book is null){
                return BadRequest();
            }
            book.GenreId=updatedBook.GenreId!=default? updatedBook.GenreId:book.GenreId;
            book.PageCount=updatedBook.PageCount!=default? updatedBook.PageCount:book.PageCount;
            book.PublishDate=updatedBook.PublishDate!=default? updatedBook.PublishDate:book.PublishDate;
            book.Title=updatedBook.Title!=default? updatedBook.Title:book.Title;
            _context.SaveChanges();
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id){
            var book=_context.Books.SingleOrDefault(b=>b.id==id);
            if (book is null)
                return BadRequest();

            _context.Books.Remove(book);
            _context.SaveChanges();
            return Ok();
        }
    }
}

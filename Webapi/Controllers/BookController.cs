using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Webapi.Application.BookOperations.Commands.CreateBook;
using Webapi.Application.BookOperations.Commands.DeleteBook;
using Webapi.Application.BookOperations.Commands.UpdateBook;
using Webapi.Application.BookOperations.Queries;
using Webapi.Application.BookOperations.Queries.GetBookById;
using Webapi.DBOperations;
using static Webapi.Application.BookOperations.Commands.CreateBook.CreateBookCommand;

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
        public IActionResult GetBooks(){
            GetBooksQuery getBooksQuery=new(_context);
            var result=getBooksQuery.Handle();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id){
            try
            {
                GetBookByIdQuery getBookByIdQuery=new(_context);
                getBookByIdQuery.id=id;
                var result=getBookByIdQuery.Handle();
                return Ok(result);    
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);   
            }
        }

        //[HttpGet("{id}")]
        //public Book Get([FromQuery] string id){
        //    var book=BookList.Where(b=>b.id==Convert.ToInt32(id)).SingleOrDefault();
        //    return book;
        //}

        [HttpPost]
        public IActionResult AddBook([FromBody] CreateBookModel newBook){
            CreateBookCommand createBookcommand=new(_context);

            try
            {
                createBookcommand.Model=newBook;
                createBookcommand.Handle();                 
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok(); 
        }

        [HttpPut("{id}")]
        public IActionResult UpdateBook(int id ,[FromBody] UpdateBookModel updatedBook){
            UpdateBookCommand updateBookCommand=new(_context);

            try
            {
                updateBookCommand.model=updatedBook;
                updateBookCommand.id=id;
                updateBookCommand.Handle();
            }
            catch (Exception ex)
            {
                
                return BadRequest(ex.Message);
            }

            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id){

            try
            {
                DeleteBookCommand deleteBookCommand=new(_context);
                deleteBookCommand.bookId=id;
                deleteBookCommand.Handle();    
            }
            catch (Exception ex)
            {
                
                return BadRequest(ex.Message);
            }
            
            return Ok();
        }
    }
}

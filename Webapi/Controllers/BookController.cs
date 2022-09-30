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
    }
}

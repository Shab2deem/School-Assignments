using LibraryWebAPI.DBMODEL;
using LibraryWebAPI.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        public DataBaseContext context { get; set; }
        public BooksController()
        {
            context = new DataBaseContext();
        }   
        [HttpGet("price-greater-than/{price}")]
        public IActionResult Get([FromRoute]int price)
        {
            var listofBooks = context.Books.Where(a => a.Price > price).Select(n=>new BooksDTO() { Id = n.Id, Author= n.Author, AvailableCopies=n.AvailableCopies, Price=n.Price, PublishedYear=n.PublishedYear, Title=n.Title }).ToList();
            
            return Ok(listofBooks);
        
        }
        [HttpGet("price-between")]
        public IActionResult GetAllBooksBetween(int min = 0, int max=int.MaxValue)
        {
            var listofBooks = context.Books.Where(a => a.Price > min&&a.Price<max).Select(n => new BooksDTO() { Id = n.Id, Author = n.Author, AvailableCopies = n.AvailableCopies, Price = n.Price, PublishedYear = n.PublishedYear, Title = n.Title }).ToList();

            return Ok(listofBooks);

        }
        [HttpGet("search")]
        public IActionResult Getbytitle(string title)
        {
            var book = context.Books.Where(a => a.Title.Contains(title)).Select(n => new BooksDTO() { Id = n.Id, Author = n.Author, AvailableCopies = n.AvailableCopies, Price = n.Price, PublishedYear = n.PublishedYear, Title = n.Title }).ToList();

            return Ok(book);
        }
        [HttpGet("first")]
        public IActionResult getfirst()
        {
            var book=context.Books.Select(n => new BooksDTO() { Id = n.Id, Author = n.Author, AvailableCopies = n.AvailableCopies, Price = n.Price, PublishedYear = n.PublishedYear, Title = n.Title }).FirstOrDefault();


            return Ok(book);
        }
        [HttpGet("first-available")]
        public IActionResult GetAvailable()
        {
            var book = context.Books.Where(a=>a.AvailableCopies>0).Select(n => new BooksDTO() { Id = n.Id, Author = n.Author, AvailableCopies = n.AvailableCopies, Price = n.Price, PublishedYear = n.PublishedYear, Title = n.Title }).ToList();
            return Ok(book);
        }
        [HttpGet("book/{id}")]
        public IActionResult Getbyid(int id)
        {
            return Ok(context.Books.Select(n => new BooksDTO() { Id = n.Id, Author = n.Author, AvailableCopies = n.AvailableCopies, Price = n.Price, PublishedYear = n.PublishedYear, Title = n.Title }).Where(a => a.Id == id).FirstOrDefault());
            

        }
        [HttpGet("last")]
        public IActionResult GetLast()
        {
            return Ok(context.Books.Select(n => new BooksDTO() { Id = n.Id, Author = n.Author, AvailableCopies = n.AvailableCopies, Price = n.Price, PublishedYear = n.PublishedYear, Title = n.Title }).LastOrDefault());
            
        }
        [HttpGet("exists/{id}")]
        public IActionResult Exists(int id) {
        
            var book = context.Books.Any(a=>a.Id==id);  

            return Ok(book);
        
        
        }
    }
}

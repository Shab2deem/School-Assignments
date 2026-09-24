using LibraryWebAPI.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LibraryWebAPI.DTOs
{
    public class BooksDTO
    {
  
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
       
        public int PublishedYear { get; set; }
       
        public decimal Price { get; set; }
       
        public int AvailableCopies { get; set; }
      

    }
}

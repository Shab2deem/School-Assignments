using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.VisualBasic;

namespace LibraryWebAPI.Models
{
    
    public class Book
    {
        [Key]
        public int Id { get; set; }
        [Required,MaxLength(200)]
        public string Title { get; set; }
        [Required,MaxLength(100)]
        public string Author { get; set; }
        [Required,Range(1900,2026)]
        public int PublishedYear { get; set; }
        [Required,Range(0,int.MaxValue)]
        public decimal Price { get; set; }
        [Required,Range(0,int.MaxValue)]
        public int AvailableCopies { get; set; }
        public Category? Category { get; set; }

        
        public int? CategoryId {  get; set; }
        public ICollection<BorrowRecord>? BorrowRecords { get; set; } = new List<BorrowRecord>();
        
    }
}

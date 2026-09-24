using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryWebAPI.Models
{
    public class BorrowRecord
    {
        [Key]
        public int Id { get; set; }
        [Required] 
        public DateTime BorrowDate { get; set; }
        
        public DateTime? ReturnDate { get; set; }

        [ForeignKey("bookId")]
        public int bookId { get; set; }
        [ForeignKey("memberId")]
        public int memberId { get; set; }
        

        public Book? book { get; set; }
        public Member? member { get; set; }



    }
}

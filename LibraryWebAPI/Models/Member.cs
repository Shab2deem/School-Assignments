using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices;

namespace LibraryWebAPI.Models
{
    public class Member
    {
        [Required]
        public int Id { get; set; }
        [Required,MaxLength(150)]
        public string FullName { get; set; }
        [Required,EmailAddress]
        public string Email { get; set; }
        [MaxLength(20),Phone]
        public string ?PhoneNumber {  get; set; }
        public ICollection<BorrowRecord> BorrowRecords { get; set; }=new List<BorrowRecord>();
        [ForeignKey("BorrowRecordsId")]
        public int BorrowRecordId { get; set; }
    }
}

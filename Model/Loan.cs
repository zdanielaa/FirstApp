using System.ComponentModel.DataAnnotations;
namespace FirstApp.Model
{
    public class Loan
    {
        [Key]
        public int LoanId { get; set; }
        public int CopyId { get; set; }
        public BookCopy BookCopy { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public DateTime LoanDate { get; set; }
        public DateTime DueDate { get; set;}
        public DateTime ReturnDate { get; set; }
        public string LoanState { get; set; }
        public string LoanFine { get; set;}
    }
}

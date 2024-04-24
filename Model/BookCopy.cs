using System.ComponentModel.DataAnnotations;
namespace FirstApp.Model
{
    public class BookCopy
    {
        [Key]
        public int BookCopyId { get; set; }
        public int BookId { get; set; }
        public Book Book { get; set; }
        public string SerialNumber  { get; set; }
        public string CopyState {get; set; }
        public string CopySite { get; set; }
    }
}

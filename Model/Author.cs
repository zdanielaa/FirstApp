using System.ComponentModel.DataAnnotations;
namespace FirstApp.Model
{
    public class Author
    {
        [Key]
        public int AuthorId { get; set; }
        public string AuthorFirstName { get; set; }
        public string AuthorLastName { get; set; }
        public string Nationality { get; set; }
        public string Biography { get; set; }
        public string Photo { get; set; }

    }
}

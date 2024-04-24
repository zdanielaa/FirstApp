using System.ComponentModel.DataAnnotations;
namespace FirstApp.Model
{
    public class Book
    {
        [Key]
        public int BookId { get; set; }
        public string Title { get; set; }
        public int GenreId { get; set; }
        public Genre Genre { get; set; }
        public int AuthorId { get; set; }
        public Author Author { get; set; }
        public DateTime DatePublished { get; set; }
        public string Synopsis { get; set; }
        public string Cover { get; set; }

    }
}

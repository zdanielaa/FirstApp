using System.ComponentModel.DataAnnotations;
namespace FirstApp.Model
{
    public class Genre
    {
        [Key]
        public int GenreId { get; set; }
        public string GenreName { get; set; }
        public string GenreDescription { get; set;}
    }
}

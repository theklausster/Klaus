using System.ComponentModel.DataAnnotations;

namespace DAL.Entities
{
    public class Post
    {
        public Post()
        {

        }

        [Range(1, 1000, ErrorMessage = "There are no records with this ID")]
        public int? Id { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string ImageUrl { get; set; }
        [Required]
        public string Title { get; set; }
    }
}
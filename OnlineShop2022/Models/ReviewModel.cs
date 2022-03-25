using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineShop2022.Models
{
    public class ReviewModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Body { get; set; }

        [Required]

        [Range(0, 5, ErrorMessage = "Please use values between 0 to 5")]
        public int Rating { get; set; }

        [Required]
        public int ProductId { get; set; }
    }
}

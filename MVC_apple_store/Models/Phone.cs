using System.ComponentModel.DataAnnotations;

namespace MVC_apple_store.Models
{
    public class Phone
    {
        public int Id { get; set; }
        [Required]
        public string Model { get; set; }
        [Required]
        public string Color { get; set; }
        public decimal Price { get; set; }
        public int Memory { get; set; }
        public string? Description { get; set; }
    }
}

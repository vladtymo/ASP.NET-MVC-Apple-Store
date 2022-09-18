using System.ComponentModel.DataAnnotations;

namespace DataAccess.Entities
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
        public string ImagePath { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace ClientOrderApp.Models
{
    public class Product
    {
        public int Id { get; set; }
        [Required]
        public string Code { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public decimal Price { get; set; }
    }
}

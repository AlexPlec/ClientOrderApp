using System.ComponentModel.DataAnnotations;

namespace ClientOrderApp.Models
{
    public class Client
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public DateTime Birthdate { get; set; }
        [Required]
        public Gender Gender { get; set; }
        public ICollection<Order> Orders { get; set; } = new List<Order>();
    }
}

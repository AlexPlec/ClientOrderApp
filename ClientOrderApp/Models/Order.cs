using System.ComponentModel.DataAnnotations;

namespace ClientOrderApp.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        [Required]
        public Client Client { get; set; }
        public int ProductId { get; set; }
        [Required]
        public Product Product { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public OrderStatus Status { get; set; }
    }
}

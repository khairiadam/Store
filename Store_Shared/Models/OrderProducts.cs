using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Store_Shared.Models
{
    public class OrderProducts
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        [Column(Order = 0)]
        public string Id { get; set; }

        public Order Order { get; set; }
        public string OrderId { get; set; }

        public Product Product { get; set; }
        public string ProductId { get; set; }

        public int Quantity { get; set; }
    }
}
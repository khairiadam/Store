using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Store_Shared.Models
{
    public class Order
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        [Column(Order = 0)]
        public string Id { get; set; }
        
        public ApplicationUser User { get; set; }
        [Required] public string UserId { get; set; }

        public DateTime OrderDate { get; set; }
        
        public Status OrderStatus { get; set; }
        [JsonIgnore] public DateTime CreationDate { get; set; }

        public Order()
        {
            CreationDate = DateTime.Now;
            this.OrderStatus = Status.Pending;
        }
    }
}
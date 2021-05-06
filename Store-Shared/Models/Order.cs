using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Store_Shared.Models
{
    public class Order
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key, Column(Order = 0)]
        public string Id { get; set; }
        public ApplicationUser User { get; set; }
        public DateTime OrderDate { get; set; }
        [JsonIgnore]
        public DateTime CreationDate { get; set; }
        public Status OrderStatus { get; set; }


        public Order()
        {
            CreationDate = DateTime.Now;
        }
    }
}

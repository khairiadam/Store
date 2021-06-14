﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Store_Shared.Models
{
    public class Order
    {
        public Order()
        {
            CreationDate = DateTime.Now;
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        [Column(Order = 0)]
        public string Id { get; set; }

        public ApplicationUser User { get; set; }
        public DateTime OrderDate { get; set; }

        [JsonIgnore] public DateTime CreationDate { get; set; }

        public Status OrderStatus { get; set; }
    }
}
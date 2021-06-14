using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Store_Shared.Models
{
    public class Images
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        [Column(Order = 0)]
        public string Id { get; set; }

        [JsonIgnore] public Product ProductImg { get; set; }

        public byte[] Image { get; set; }
        public string ProductImgId { get; set; }
    }
}
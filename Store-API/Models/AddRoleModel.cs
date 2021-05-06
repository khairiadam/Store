using System.ComponentModel.DataAnnotations;

namespace Store_API.Models
{
    public class AddRoleModel
    {
        [Required]
        public string UserId { get; set; }

        [Required]
        public string Role { get; set; }

    }
}

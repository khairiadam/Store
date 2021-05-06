using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Store_API.Models
{
    public class RegisterModel
    {
        [Required, StringLength(100)]
        public string FirstName { get; set; }

        [Required, StringLength(100)]
        public string LastName { get; set; }

        [Required, StringLength(50)]
        public string Username { get; set; }

        [Required, StringLength(128)]
        public string Email { get; set; }

        [Required, StringLength(256)]
        public string Password { get; set; }
        [AllowNull] public DateTime BirthDate { get; set; }
        [Required] public string Gender { get; set; }
        [Required] public string Address { get; set; }
        [Required] public string Country { get; set; }
        [Required] public string State { get; set; }
        [Required] public string City { get; set; }
        [Required] public string ZipCode { get; set; }

    }

}

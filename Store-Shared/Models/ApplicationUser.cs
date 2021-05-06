using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store_Shared.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required, MaxLength(50)]
        public string FirstName { get; set; }


        [Required, MaxLength(50)]
        public string LastName { get; set; }
        [AllowNull] public DateTime BirthDate { get; set; }
        [Required] public string Gender { get; set; }
        [Required] public string Address { get; set; }
        [Required] public string Country { get; set; }
        [Required] public string State { get; set; }
        [Required] public string City { get; set; }
        [Required] public string ZipCode { get; set; }
    }
}

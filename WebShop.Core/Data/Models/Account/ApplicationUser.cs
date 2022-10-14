using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace WebShop.Core.Data.Models.Account
{
    public class ApplicationUser : IdentityUser
    {
        [MaxLength(20)]
        public string? FirstName { get; set; }

        [MaxLength(20)]
        public string? lastName { get; set; }
    }
}

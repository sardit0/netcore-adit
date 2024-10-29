using Microsoft.AspNetCore.Identity;


namespace Inventaris.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FullName { get; set; }
    }
}

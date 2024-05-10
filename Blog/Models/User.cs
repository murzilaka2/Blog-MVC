using Microsoft.AspNetCore.Identity;

namespace Blog.Models
{
    public class User : IdentityUser
    {
        public int PulicationsCount { get; set; }
        public string? Name { get; set; }
    }
}

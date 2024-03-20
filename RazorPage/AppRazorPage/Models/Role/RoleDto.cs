using Eshop.RazorPage.Infrastructure;

namespace AppRazorPage.Models.Role
{
    public class RoleDto
    {
        public long id { get; set; }
        public DateTime CreationDate { get; set; }
        public string? Title { get; set; }
        public List<Permission> Permissions { get; set; }
    }
}

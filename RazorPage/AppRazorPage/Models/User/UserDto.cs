using AppRazorPage.Models.Role;

namespace AppRazorPage.Models.User
{
    public class UserDto
    {
        public string UserName { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public RoleDto Role { get; set; }
        public bool IsActive { get; set; }
    }
    public class UserTokenDto
    {
        public long UserId { get; set; }
        public string HashJwtToken { get; set; }
        public string HashRefreshToken { get; set; }
        public DateTime TokenExpireDate { get; set; }
        public DateTime RefreshTokenExpireDate { get; set; }
        public string Device { get; set; }
    }
}

using Common.Query;
using Shop.Domain.RoleAgg;
using Shop.Domain.UserAgg;

namespace Shop.Query.Users.DTOs
{
    public class UserDto : BaseDto
    {
        public string UserName { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public List<UserRoleDto> Roles { get; set; }
        public bool IsActive { get; set; }
    }

    public class UserRoleDto
    {
        public long RoleId { get; set; }
        public string RoleTitle { get; set; }
    }
}

using Common.Query;
using Shop.Domain.RoleAgg.Enums;

namespace Shop.Query.Roles.DTOs
{
    public class RoleFilterData : BaseDto
    {
        public string Title { get; set; }
        public List<Permission> permissions { get; set; }
    }
}

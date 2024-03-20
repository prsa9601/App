using Common.Query.Filter;

namespace Shop.Query.Roles.DTOs
{
    public class RoleFilterParam : BaseFilterParam
    {
        public long? RoleId { get; set; }
        public string? Title { get; set; }
    }
}

using Microsoft.EntityFrameworkCore;
using Shop.Domain.RoleAgg;
using Shop.Domain.RoleAgg.Repository;
using Shop.Infrastructure._Utilities;

namespace Shop.Infrastructure.Persistent.Ef.RoleAgg
{
    public class RoleRepository : BaseRepository<Role>, IRoleRepository
    {
        private readonly ShopContext _shopContext;
        public RoleRepository(ShopContext context) : base(context)
        {
            _shopContext = context;
        }

        public async Task<int> Delete(long RoleId)
        {
            try
            {
                var role = await _shopContext.Roles.FirstOrDefaultAsync(i => i.id == RoleId);
                _shopContext.Roles.Remove(role);
                return 200;
            }
            catch { return 404; }
        }
        public async Task<Role> GetRoleByTitle(string roleTitle)
        {
            try
            {
                var role = await _shopContext.Roles.FirstOrDefaultAsync(i => i.Title == roleTitle);
                return role;
            }
            catch { return null; }
        }
    }
}

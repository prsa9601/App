using Shop.Infrastructure.Persistent.Ef;
using Common.Query;
using Microsoft.EntityFrameworkCore;
using Shop.Query.Roles.DTOs;


namespace Shop.Query.Roles.GetByFilter
{
    public class GetRoleByFilterQuery : QueryFilter<RoleFilterResult, RoleFilterParam>
    {
        public GetRoleByFilterQuery(RoleFilterParam filterParams) : base(filterParams)
        {
        }
    }
    public class GetRoleByFilterQueryHandler : IQueryHandler<GetRoleByFilterQuery, RoleFilterResult>
    {
        private readonly ShopContext _context;

        public GetRoleByFilterQueryHandler(ShopContext context)
        {
            _context = context;
        }

        public async Task<RoleFilterResult> Handle(GetRoleByFilterQuery request, CancellationToken cancellationToken)
        {
            var @params = request.FilterParams;
            var result = _context.Roles.OrderByDescending(d => d.id).AsQueryable();

            //if (!string.IsNullOrWhiteSpace(@params.Slug))
            //    result = result.Where(r => r.Slug == @params.Slug);

            if (!string.IsNullOrWhiteSpace(@params.Title))
                result = result.Where(r => r.Title.Contains(@params.Title));

            if (@params.RoleId != null)
                result = result.Where(r => r.id == @params.RoleId);

            var skip = (@params.PageId - 1) * @params.Take;
            var model = new RoleFilterResult()
            {
                Data = await result.Skip(skip).Take(@params.Take).Select(s => s.MapListData())
                    .ToListAsync(cancellationToken),
                FilterParams = @params
            };
            model.GeneratePaging(result, @params.Take, @params.PageId);
            return model;
        }
    }
}

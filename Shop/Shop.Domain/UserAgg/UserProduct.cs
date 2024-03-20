using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Domain;

namespace Shop.Domain.UserAgg
{
    public class UserProduct : BaseEntity
    {
        public UserProduct(long productId)
        {
            ProductId = productId;
        }

        public long ProductId { get; private set; }
        public long UserId { get; internal set; }
    }
}

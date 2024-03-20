using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Application;

namespace Shop.Application.Product.Update
{
    public record UpdateProductCommand(long ProductId, string Title, string Price) : IBaseCommand;
}
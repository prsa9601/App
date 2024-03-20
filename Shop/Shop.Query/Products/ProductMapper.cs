using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shop.Domain.ProductAgg;
using Shop.Query.Products.DTOs;

namespace Shop.Query.Products
{
    public static class ProductMapper
    {
    public static ProductFilterData MapListData(this Product product)
    {
        return new ProductFilterData()
        {
            Title = product.Title,
            Price = product.Price,
            Id = product.id,
            CreationDate = product.CreationDate
        };
    }
    }
}

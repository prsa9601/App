

using Eshop.RazorPage.Models;

namespace Shop.Query.Products.DTOs
{
    public class ProductFilterParams : BaseFilterParam
    {
        public long? ProductId { get; set; }
        public string? Title { get; set; }
    }
}

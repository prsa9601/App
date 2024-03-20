using Common.Query.Filter;

namespace Shop.Query.Products.DTOs
{
    public class ProductFilterParam : BaseFilterParam
    {
        public long? ProductId { get; set; }
        public string? Title { get; set; }
    }
}

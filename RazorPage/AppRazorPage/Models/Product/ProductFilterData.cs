//using Common.Query;
using Eshop.RazorPage.Models;

namespace Shop.Query.Products.DTOs
{
    public class ProductFilterData : BaseDto
    {
        public string Title { get; set; }
        public string Price { get; set; }
    }
}

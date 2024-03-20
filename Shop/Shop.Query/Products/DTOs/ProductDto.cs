using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Query;

namespace Shop.Query.Products.DTOs
{
    public class ProductDto : BaseDto
    {
        public string Title { get; set; }
        public string Price { get; set; }
    }
}

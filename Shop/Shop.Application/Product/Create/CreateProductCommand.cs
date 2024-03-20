using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Application;

namespace Shop.Application.Product.Create
{
    public class CreateProductCommand : IBaseCommand
    {
        public string Title { get; set; }
        public string Price { get; set; }
    }
}

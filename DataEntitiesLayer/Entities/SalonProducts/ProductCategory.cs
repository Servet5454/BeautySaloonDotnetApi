using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace DataEntitiesLayer.Entities.SalonProducts
{
    public class ProductCategory
    {
        public int ProductId { get; set; }
        public string? CategoryName { get; set; }
        public string? Description { get; set; }
        public ICollection<Product>? Products { get; set; }
    }
}

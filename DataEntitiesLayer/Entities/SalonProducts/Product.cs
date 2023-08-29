using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataEntitiesLayer.Entities.SalonProducts
{
    public class Product
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }  // Kategori ID'si
        public string? ProductName { get; set; }
        public int ProductPrice { get; set; }        
        public string? Description { get; set; }
        public int StockQuantity { get; set; }
        public virtual ProductCategory? ProductCategory { get; set; }
    }
}

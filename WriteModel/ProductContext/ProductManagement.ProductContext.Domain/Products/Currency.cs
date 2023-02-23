using Framework.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagement.ProductContext.Domain.Products
{
    public class Currency : IEntityBase
    {

        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<ProductPrice>  productPrices { get; set; }
    }
  

}

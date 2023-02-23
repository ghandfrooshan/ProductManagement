using Framework.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductManagement.ProductContext.Domain.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagement.ProductContext.Infrastructure.Persistence.Products.Mapping
{
    public class ProductPropertyMapping : EntityMappingBase<ProductProperty>
    {
        public override void Configure(EntityTypeBuilder<ProductProperty> builder)
        {
            Initial(builder);

          
        }
    }
}

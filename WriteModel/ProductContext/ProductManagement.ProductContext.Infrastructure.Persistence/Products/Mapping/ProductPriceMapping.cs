using Framework.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductManagement.ProductContext.Domain.Products;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagement.ProductContext.Infrastructure.Persistence.Products.Mapping
{
    public class ProductPriceMapping : EntityMappingBase<ProductPrice>
    {
        public override void Configure(EntityTypeBuilder<ProductPrice> builder)
        {
            Initial(builder);
            builder.Property(a => a.Price).HasColumnType(nameof(SqlDbType.Float)).IsRequired();
            builder.Property(a => a.FromDate).HasColumnType(nameof(SqlDbType.Date)).IsRequired();
            builder.Property(a => a.ToDate).HasColumnType(nameof(SqlDbType.Date)).IsRequired();

          
        }
    }
}

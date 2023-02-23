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
    public class ProductMapping : EntityMappingBase<Product>
    {
        public override void Configure(EntityTypeBuilder<Product> builder)
        {
            Initial(builder);
            builder.Property(a => a.Name).HasColumnType(nameof(SqlDbType.NVarChar)).HasMaxLength(300).IsRequired();

            builder.Property(a => a.IsActice).HasColumnType(nameof(SqlDbType.Bit)).HasDefaultValue(true).IsRequired();

            


            builder.HasMany(x => x.ProductPriceList).WithOne(x => x.product)
               .HasForeignKey(x => x.ProductId);
            builder.HasMany(x => x.ProductPropertyList).WithOne(x => x.product)
              .HasForeignKey(x => x.ProductId);
        }
    }
}

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
    public class CurrencyMapping : EntityMappingBase<Currency>
    {
        public override void Configure(EntityTypeBuilder<Currency> builder)
        {
            Initial(builder);
            builder.Property(a => a.Name).HasColumnType(nameof(SqlDbType.NVarChar)).HasMaxLength(20).IsRequired();


            builder.HasMany(x => x.productPrices).WithOne(x => x.Currency)
                     .HasForeignKey(x => x.CurrencyId)
                     .OnDelete(DeleteBehavior.Restrict);
        }
    }
}

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
    public class PropertyMapping : EntityMappingBase<Property>
    {
        public override void Configure(EntityTypeBuilder<Property> builder)
        {
            Initial(builder);
            builder.Property(a => a.Name).HasColumnType(nameof(SqlDbType.NVarChar)).HasMaxLength(250).IsRequired();

            builder.HasMany(x => x.productProperties).WithOne(x => x.Property)
                   .HasForeignKey(x => x.PropertyId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}

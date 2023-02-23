using Microsoft.EntityFrameworkCore;

namespace ProductManagement.ReadModel.Context.Models;

public partial class ProductManagementContext //:DbContext
{
    public DbSet<ViewProductPrice>  ProductPriceDtos { get; set; }

  
    partial void OnModelCreatingPartial(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ViewProductPrice>(e =>
        {
            //e.HasNoKey();
            e.HasKey(e => e.ProductId);
        });
    }

}
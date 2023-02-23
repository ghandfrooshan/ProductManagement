using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProductManagement.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class DefinationData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO ProductContext.Currency( Name)\r\nVALUES\r\n( N'USD' ),\r\n( N'EUR' ),\r\n( N'lIRA' )");
            migrationBuilder.Sql("INSERT INTO ProductContext.ProductCategory( Name)\r\nVALUES\r\n( N'Chocolate' ),\r\n( N'Biscuit' ),\r\n( N'cake' )");
            migrationBuilder.Sql("INSERT INTO ProductContext.Property( Name)\r\nVALUES\r\n( N'flavour' ),\r\n( N'PackageType' ),\r\n( N'ProductionType' )");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}

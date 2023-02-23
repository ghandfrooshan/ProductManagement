using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProductManagement.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class ProductPriceData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO ProductContext.ProductPrice\r\n(\r\n    Id,ProductId, Price,CurrencyId, FromDate,ToDate\r\n)\r\nVALUES\r\n(   1,  1,10.0, 1,'2022-01-01', '2022-05-01'  ),\r\n(   2,  1,15.0, 2,'2022-01-01', '2022-04-01'  ),\r\n(   3,  1,10.0, 3,'2022-01-01', '3066-03-20'  ),\r\n(   4,  1,15.0, 1,'2022-05-02', '3066-03-20'  ),\r\n(   5,  1,14.0, 2,'2022-04-02', '2022-05-01'  ),\r\n(   6,  1,16.0, 2,'2022-05-02', '3066-03-20'  ),\r\n\r\n(   7,  2,10.0, 1,'2022-01-01', '3066-03-20'  ),\r\n(   8,  2,16.0, 2,'2022-01-01', '3066-03-20'  ),\r\n(   9,  2,18.0, 3,'2022-01-01', '3066-03-20'  ),\r\n(   10,  4,15.0, 1,'2022-01-01', '3066-03-20'  ),\r\n(   11,  4,18.0, 2,'2022-01-01', '3066-03-20'  ),\r\n(   12,  4,20.0, 3,'2022-01-01', '3066-03-20'  ),\r\n(   13,  6,30.0, 1,'2022-01-01', '3066-03-20'  ),\r\n(   14,  6,32.0, 2,'2022-01-01', '3066-03-20'  ),\r\n(   15,  6,50.0, 3,'2022-01-01', '3066-03-20'  )");
            migrationBuilder.Sql("ALTER SEQUENCE Shared.ProductPrice\r\n RESTART WITH 16;");

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}

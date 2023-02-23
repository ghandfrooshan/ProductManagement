using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProductManagement.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class ProductData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT ProductContext.Product\r\n( Id,Name,IsActice,CategoryId)\r\nVALUES\r\n(   1,  N'Test1_1',  1,1   ),\r\n(   2,  N'Test1_2',  1,1   ),\r\n(   3,  N'Test2-3',  1,2   ),\r\n(   4,  N'Test1-4',  0,1   ),\r\n(   5,  N'Test2-2',  1,2   ),\r\n(   6,  N'Test2-3',  1,2   ),\r\n(   7,  N'Test2-4',  0,2   ),\r\n(   8,  N'Test1-6',  1,1   ),\r\n(   9,  N'Test2-1',  1,3   ),\r\n(   10,  N'Test2-2',  0,3  )\r\n");
            migrationBuilder.Sql("ALTER SEQUENCE Shared.Product\r\n RESTART WITH 11");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}

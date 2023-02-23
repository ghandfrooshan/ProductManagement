using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProductManagement.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class StructureModified : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "ProductProperty",
                newName: "ProductProperty",
                newSchema: "ProductContext");

            migrationBuilder.RenameTable(
                name: "ProductPrice",
                newName: "ProductPrice",
                newSchema: "ProductContext");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "ProductProperty",
                schema: "ProductContext",
                newName: "ProductProperty");

            migrationBuilder.RenameTable(
                name: "ProductPrice",
                schema: "ProductContext",
                newName: "ProductPrice");
        }
    }
}

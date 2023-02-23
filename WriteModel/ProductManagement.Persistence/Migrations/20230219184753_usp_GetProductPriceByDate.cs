using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProductManagement.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class uspGetProductPriceByDate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("Create PROCEDURE [dbo].[usp_GetProductPriceByDate] @date DATE\r\nAS\r\nBEGIN\r\n\r\n    ;WITH ProductPrice\r\n    AS (SELECT Id,\r\n               ProductId,\r\n               CurrencyId,\r\n               Price\r\n        FROM ProductContext.ProductPrice pp\r\n        WHERE @date\r\n        BETWEEN FromDate AND ToDate),\r\n         ProductPriceWithCurrency\r\n    AS (SELECT c.Name CurrencyName,\r\n               ISNULL(p.ProductId, 0) ProductId,\r\n               ISNULL(p.Price, 0) Price\r\n        FROM ProductContext.Currency c\r\n            LEFT JOIN ProductPrice p\r\n                ON p.CurrencyId = c.Id),\r\n         Result\r\n    AS (SELECT PivotTable.ProductId,\r\n               PivotTable.USD,\r\n               PivotTable.lIRA,\r\n               PivotTable.EUR\r\n        FROM ProductPriceWithCurrency\r\n            PIVOT\r\n            (\r\n                MIN(Price)\r\n                FOR CurrencyName IN ([EUR], [USD], [lIRA])\r\n            ) AS PivotTable)\r\n    SELECT p.Id ProductId,\r\n           r.USD,\r\n           r.lIRA,\r\n           r.EUR\r\n    FROM ProductContext.Product p\r\n        LEFT JOIN Result r\r\n            ON r.ProductId = p.Id;\r\n\r\nEND;\r\n\r\n");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}

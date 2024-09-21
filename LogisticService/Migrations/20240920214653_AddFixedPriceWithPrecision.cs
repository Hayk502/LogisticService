using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LogisticService.Migrations
{
    /// <inheritdoc />
    public partial class AddFixedPriceWithPrecision : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "FixedPrice",
                table: "Routes",
                type: "decimal(18,2)",
                precision: 18,
                scale: 2,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FixedPrice",
                table: "Routes");
        }
    }
}

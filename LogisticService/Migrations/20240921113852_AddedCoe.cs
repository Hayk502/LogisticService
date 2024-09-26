using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LogisticService.Migrations
{
    /// <inheritdoc />
    public partial class AddedCoe : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Containers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Containers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Routes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Routes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Status",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Status",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "VehicleTypes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "VehicleTypes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.AddColumn<decimal>(
                name: "Coefficient",
                table: "Status",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Coefficient",
                table: "Containers",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Coefficient",
                table: "Status");

            migrationBuilder.DropColumn(
                name: "Coefficient",
                table: "Containers");

            migrationBuilder.InsertData(
                table: "Containers",
                columns: new[] { "Id", "IsClosed" },
                values: new object[,]
                {
                    { 1, true },
                    { 2, false }
                });

            migrationBuilder.InsertData(
                table: "Routes",
                columns: new[] { "Id", "EndLocation", "FixedPrice", "StartLocation" },
                values: new object[,]
                {
                    { 1, "Berlin", 500m, "Paris" },
                    { 2, "Rome", null, "London" }
                });

            migrationBuilder.InsertData(
                table: "Status",
                columns: new[] { "Id", "IsOperational" },
                values: new object[,]
                {
                    { 1, true },
                    { 2, false }
                });

            migrationBuilder.InsertData(
                table: "VehicleTypes",
                columns: new[] { "Id", "Coefficient", "Name" },
                values: new object[,]
                {
                    { 1, 1.0m, "Sedan" },
                    { 2, 1.5m, "Truck" }
                });
        }
    }
}

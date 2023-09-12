using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class mig5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Costumers",
                columns: new[] { "Id", "Balance", "CostumerEmail", "CostumerName", "CostumerPhone", "CostumerSurname", "Point" },
                values: new object[,]
                {
                    { 1, 500, "musteri1@example.com", "Müşteri 1", "555-111-1111", "Soyadı 1", 100 },
                    { 2, 500, "musteri1@example.com", "Müşteri 2", "555-111-1111", "Soyadı 2", 100 },
                    { 3, 500, "musteri1@example.com", "Müşteri 3", "555-111-1111", "Soyadı 3", 100 },
                    { 4, 500, "musteri1@example.com", "Müşteri 4", "555-111-1111", "Soyadı 4", 100 },
                    { 5, 500, "musteri1@example.com", "Müşteri 5", "555-111-1111", "Soyadı 5", 100 },
                    { 6, 500, "musteri1@example.com", "Müşteri 6", "555-111-1111", "Soyadı 6", 100 },
                    { 7, 500, "musteri1@example.com", "Müşteri 7", "555-111-1111", "Soyadı 7", 100 },
                    { 8, 500, "musteri1@example.com", "Müşteri 8", "555-111-1111", "Soyadı 8", 100 },
                    { 9, 500, "musteri1@example.com", "Müşteri 9", "555-111-1111", "Soyadı 9", 100 },
                    { 10, 500, "musteri1@example.com", "Müşteri 10", "555-111-1111", "Soyadı 10", 100 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Costumers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Costumers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Costumers",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Costumers",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Costumers",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Costumers",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Costumers",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Costumers",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Costumers",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Costumers",
                keyColumn: "Id",
                keyValue: 10);
        }
    }
}

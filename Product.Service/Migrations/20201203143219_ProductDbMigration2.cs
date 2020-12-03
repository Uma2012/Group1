using Microsoft.EntityFrameworkCore.Migrations;

namespace Product.Service.Migrations
{
    public partial class ProductDbMigration2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ImageUrl", "Name", "Price", "Quantity" },
                values: new object[] { "..\\Group1\\Product.Service\\Images\\Frozen Cheesecake.jpg", "Frozen cheescake", 50.0, 10 });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "ImageUrl", "Name", "Price", "Quantity" },
                values: new object[,]
                {
                    { 2, "Description", "..\\Group1\\Product.Service\\Images\\Pizza.jpg", "Frozen pizza", 75.0, 15 },
                    { 3, "Description", "..\\Group1\\Product.Service\\Images\\Lasagna.jpg", "Frozen lasagna", 125.0, 20 },
                    { 4, "Description", "..\\Group1\\Product.Service\\Images\\Salmon.jpg", "Frozen salmon", 280.0, 10 },
                    { 5, "Description", "..\\Group1\\Product.Service\\Images\\Chicken Pad Thai.jpg", "Frozen phad thai", 75.0, 15 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ImageUrl", "Name", "Price", "Quantity" },
                values: new object[] { "..\\Group1\\Product.Service\\Images\\Good_Food.jpg", "Test", 200.0, 15 });
        }
    }
}

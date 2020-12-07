using Microsoft.EntityFrameworkCore.Migrations;

namespace Order.Service.Migrations
{
    public partial class AddingData_Payment_Delivery : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Deliveries",
                columns: new[] { "Id", "Name", "Price" },
                values: new object[,]
                {
                    { 1, "homedelivery", 50.0 },
                    { 2, "takeaway", 0.0 }
                });

            migrationBuilder.InsertData(
                table: "PaymentMethods",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "swish" },
                    { 2, "card" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Deliveries",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Deliveries",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "PaymentMethods",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "PaymentMethods",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}

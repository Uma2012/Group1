using Microsoft.EntityFrameworkCore.Migrations;

namespace Product.Service.Migrations
{
    public partial class Alteration_ImageUrl_Lasagna : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "ImageUrl",
                value: "/Images/Lasagna.jpg");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "ImageUrl",
                value: "/Images/Images/Lasagna.jpg");
        }
    }
}

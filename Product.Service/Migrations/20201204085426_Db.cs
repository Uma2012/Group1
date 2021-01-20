using Microsoft.EntityFrameworkCore.Migrations;

namespace Product.Service.Migrations
{
    public partial class Db : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "ImageUrl", "Name", "Price", "Quantity" },
                values: new object[,]
                {
                    { 1, "Description", "..\\Group1\\Product.Service\\Images\\Frozen Cheesecake.jpg", "Frozen cheescake", 50.0, 10 },
                    { 2, "Description", "..\\Group1\\Product.Service\\Images\\Pizza.jpg", "Frozen pizza", 75.0, 15 },
                    { 3, "Description", "..\\Group1\\Product.Service\\Images\\Lasagna.jpg", "Frozen lasagna", 125.0, 20 },
                    { 4, "Description", "..\\Group1\\Product.Service\\Images\\Salmon.jpg", "Frozen salmon", 280.0, 10 },
                    { 5, "Description", "..\\Group1\\Product.Service\\Images\\Chicken Pad Thai.jpg", "Frozen phad thai", 75.0, 15 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}

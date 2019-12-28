using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAppAPI.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BrandItems",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BrandItems", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CountryItems",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CountryItems", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CarItems",
                columns: table => new
                {
                    VIN = table.Column<string>(nullable: false),
                    BrandID = table.Column<int>(nullable: false),
                    Model = table.Column<string>(maxLength: 50, nullable: true),
                    ProductionYear = table.Column<int>(nullable: false),
                    Mileage = table.Column<int>(nullable: false),
                    Fuel = table.Column<string>(nullable: false),
                    EnginePower = table.Column<int>(nullable: false),
                    Color = table.Column<string>(maxLength: 50, nullable: true),
                    Photo = table.Column<string>(nullable: true),
                    NetPrice = table.Column<float>(nullable: false),
                    Description = table.Column<string>(maxLength: 5000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarItems", x => x.VIN);
                    table.ForeignKey(
                        name: "FK_CarItems_BrandItems_BrandID",
                        column: x => x.BrandID,
                        principalTable: "BrandItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CarItems_BrandID",
                table: "CarItems",
                column: "BrandID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CarItems");

            migrationBuilder.DropTable(
                name: "CountryItems");

            migrationBuilder.DropTable(
                name: "BrandItems");
        }
    }
}

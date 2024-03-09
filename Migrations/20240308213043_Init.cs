using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VerticalSliceArchitecture.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Platforms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Manufacturer = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Platforms", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Games",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Publisher = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PlatformId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Games_Platforms_PlatformId",
                        column: x => x.PlatformId,
                        principalTable: "Platforms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Platforms",
                columns: new[] { "Id", "Manufacturer", "Name" },
                values: new object[] { 1, "Microsoft", "Xbox Series X" });

            migrationBuilder.InsertData(
                table: "Platforms",
                columns: new[] { "Id", "Manufacturer", "Name" },
                values: new object[] { 2, "Sony", "PlayStation 5" });

            migrationBuilder.InsertData(
                table: "Platforms",
                columns: new[] { "Id", "Manufacturer", "Name" },
                values: new object[] { 3, "Nintendo", "Nintendo Switch" });

            migrationBuilder.InsertData(
                table: "Games",
                columns: new[] { "Id", "Name", "PlatformId", "Publisher" },
                values: new object[] { 10, "Horizon Forbidden West", 2, "Sony Interactive Entertainment" });

            migrationBuilder.InsertData(
                table: "Games",
                columns: new[] { "Id", "Name", "PlatformId", "Publisher" },
                values: new object[] { 11, "Animal Crossing: New Horizons", 3, "Nintendo" });

            migrationBuilder.InsertData(
                table: "Games",
                columns: new[] { "Id", "Name", "PlatformId", "Publisher" },
                values: new object[] { 12, "Halo Infinite", 1, "Xbox Game Studios" });

            migrationBuilder.CreateIndex(
                name: "IX_Games_PlatformId",
                table: "Games",
                column: "PlatformId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Games");

            migrationBuilder.DropTable(
                name: "Platforms");
        }
    }
}

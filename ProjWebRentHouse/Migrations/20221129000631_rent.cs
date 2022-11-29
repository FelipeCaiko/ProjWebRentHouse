using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjWebRentHouse.Migrations
{
    public partial class rent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RealtyRent",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientId = table.Column<int>(type: "int", nullable: false),
                    RealtyId = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RealtyRent", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RealtyRent_Client_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Client",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RealtyRent_Realty_RealtyId",
                        column: x => x.RealtyId,
                        principalTable: "Realty",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RealtyRent_ClientId",
                table: "RealtyRent",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_RealtyRent_RealtyId",
                table: "RealtyRent",
                column: "RealtyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RealtyRent");
        }
    }
}

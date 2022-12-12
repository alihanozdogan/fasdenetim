using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FasDenetim.Data.Migrations
{
    /// <inheritdoc />
    public partial class bilancomodel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "bilancoModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Bilanço = table.Column<string>(type: "TEXT", nullable: false),
                    OncekiYıl = table.Column<string>(type: "TEXT", nullable: false),
                    CariYıl = table.Column<string>(type: "TEXT", nullable: false),
                    HesaplanmışVeri = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bilancoModel", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "bilancoModel");
        }
    }
}

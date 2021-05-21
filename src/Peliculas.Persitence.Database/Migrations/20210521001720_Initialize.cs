using Microsoft.EntityFrameworkCore.Migrations;

namespace Peliculas.Persitence.Database.Migrations
{
    public partial class Initialize : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Peliculas");

            migrationBuilder.CreateTable(
                name: "TipoGeneros",
                schema: "Peliculas",
                columns: table => new
                {
                    TipoGeneroID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoGeneros", x => x.TipoGeneroID);
                });

            migrationBuilder.CreateTable(
                name: "Peliculas",
                schema: "Peliculas",
                columns: table => new
                {
                    PeliculaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Clave = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    TipoGeneroID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Peliculas", x => x.PeliculaID);
                    table.ForeignKey(
                        name: "FK_Peliculas_TipoGeneros_TipoGeneroID",
                        column: x => x.TipoGeneroID,
                        principalSchema: "Peliculas",
                        principalTable: "TipoGeneros",
                        principalColumn: "TipoGeneroID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "Peliculas",
                table: "TipoGeneros",
                columns: new[] { "TipoGeneroID", "Descripcion" },
                values: new object[] { 1, "Drama" });

            migrationBuilder.InsertData(
                schema: "Peliculas",
                table: "Peliculas",
                columns: new[] { "PeliculaID", "Clave", "Nombre", "TipoGeneroID" },
                values: new object[] { 1, "P001", "El silencio de los inocentes", 1 });

            migrationBuilder.CreateIndex(
                name: "IX_Peliculas_TipoGeneroID",
                schema: "Peliculas",
                table: "Peliculas",
                column: "TipoGeneroID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Peliculas",
                schema: "Peliculas");

            migrationBuilder.DropTable(
                name: "TipoGeneros",
                schema: "Peliculas");
        }
    }
}

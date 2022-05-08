using Microsoft.EntityFrameworkCore.Migrations;

namespace publicApi.Migrations
{
    public partial class first : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "usuarioType",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_usuarioType", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    firstName = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    lastName = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    userName = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    passwordHash = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    passwordSalt = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    typeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.id);
                    table.ForeignKey(
                        name: "FK_Usuarios_usuarioType_typeId",
                        column: x => x.typeId,
                        principalTable: "usuarioType",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tareas",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    message = table.Column<string>(type: "nvarchar(3000)", maxLength: 3000, nullable: true),
                    usuarioId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tareas", x => x.id);
                    table.ForeignKey(
                        name: "FK_Tareas_Usuarios_usuarioId",
                        column: x => x.usuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "usuarioType",
                columns: new[] { "id", "name" },
                values: new object[] { 1, "Usuario normal" });

            migrationBuilder.InsertData(
                table: "usuarioType",
                columns: new[] { "id", "name" },
                values: new object[] { 2, "Usuario admin" });

            migrationBuilder.CreateIndex(
                name: "IX_Tareas_usuarioId",
                table: "Tareas",
                column: "usuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_typeId",
                table: "Usuarios",
                column: "typeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tareas");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "usuarioType");
        }
    }
}

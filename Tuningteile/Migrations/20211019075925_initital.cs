using Microsoft.EntityFrameworkCore.Migrations;

namespace Tuningteile.Migrations
{
    public partial class initital : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "manufacturer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_manufacturer", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Password = table.Column<string>(type: "nvarchar(800)", maxLength: 800, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TuningPart",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ManufacturerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PartName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(34,2)", precision: 34, scale: 2, nullable: false),
                    available = table.Column<bool>(type: "bit", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TuningPart", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TuningPart_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Model",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ManufacturerId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: true),
                    Begin_Year_construction = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: true),
                    End_Year_construction = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Model", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Model_manufacturer_ManufacturerId",
                        column: x => x.ManufacturerId,
                        principalTable: "manufacturer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ModelTuningPart",
                columns: table => new
                {
                    ModelId = table.Column<int>(type: "int", nullable: false),
                    TuningPartId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModelTuningPart", x => new { x.ModelId, x.TuningPartId });
                    table.ForeignKey(
                        name: "FK_ModelTuningPart_Model_ModelId",
                        column: x => x.ModelId,
                        principalTable: "Model",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ModelTuningPart_TuningPart_TuningPartId",
                        column: x => x.TuningPartId,
                        principalTable: "TuningPart",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Model_ManufacturerId",
                table: "Model",
                column: "ManufacturerId");

            migrationBuilder.CreateIndex(
                name: "IX_ModelTuningPart_TuningPartId",
                table: "ModelTuningPart",
                column: "TuningPartId");

            migrationBuilder.CreateIndex(
                name: "IX_TuningPart_CategoryId",
                table: "TuningPart",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Username",
                table: "Users",
                column: "Username",
                unique: true,
                filter: "[Username] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ModelTuningPart");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Model");

            migrationBuilder.DropTable(
                name: "TuningPart");

            migrationBuilder.DropTable(
                name: "manufacturer");

            migrationBuilder.DropTable(
                name: "Category");
        }
    }
}

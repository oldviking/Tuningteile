using Microsoft.EntityFrameworkCore.Migrations;

namespace Tuningteile.Migrations
{
    public partial class delete_compati : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Models_compatibiliy_compatibiliyModelId_compatibiliyTuningPartId",
                table: "Models");

            migrationBuilder.DropForeignKey(
                name: "FK_TuningPart_compatibiliy_compatibiliyModelId_compatibiliyTuningPartId",
                table: "TuningPart");

            migrationBuilder.DropTable(
                name: "compatibiliy");

            migrationBuilder.DropTable(
                name: "ModelTuningPart");

            migrationBuilder.DropIndex(
                name: "IX_TuningPart_compatibiliyModelId_compatibiliyTuningPartId",
                table: "TuningPart");

            migrationBuilder.DropIndex(
                name: "IX_Models_compatibiliyModelId_compatibiliyTuningPartId",
                table: "Models");

            migrationBuilder.DropColumn(
                name: "compatibiliyModelId",
                table: "TuningPart");

            migrationBuilder.DropColumn(
                name: "compatibiliyModelId",
                table: "Models");

            migrationBuilder.DropColumn(
                name: "compatibiliyTuningPartId",
                table: "Models");

            migrationBuilder.RenameColumn(
                name: "compatibiliyTuningPartId",
                table: "TuningPart",
                newName: "ModelId");

            migrationBuilder.CreateIndex(
                name: "IX_TuningPart_ModelId",
                table: "TuningPart",
                column: "ModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_TuningPart_Models_ModelId",
                table: "TuningPart",
                column: "ModelId",
                principalTable: "Models",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TuningPart_Models_ModelId",
                table: "TuningPart");

            migrationBuilder.DropIndex(
                name: "IX_TuningPart_ModelId",
                table: "TuningPart");

            migrationBuilder.RenameColumn(
                name: "ModelId",
                table: "TuningPart",
                newName: "compatibiliyTuningPartId");

            migrationBuilder.AddColumn<int>(
                name: "compatibiliyModelId",
                table: "TuningPart",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "compatibiliyModelId",
                table: "Models",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "compatibiliyTuningPartId",
                table: "Models",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "compatibiliy",
                columns: table => new
                {
                    ModelId = table.Column<int>(type: "int", nullable: false),
                    TuningPartId = table.Column<int>(type: "int", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_compatibiliy", x => new { x.ModelId, x.TuningPartId });
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
                        name: "FK_ModelTuningPart_Models_ModelId",
                        column: x => x.ModelId,
                        principalTable: "Models",
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
                name: "IX_TuningPart_compatibiliyModelId_compatibiliyTuningPartId",
                table: "TuningPart",
                columns: new[] { "compatibiliyModelId", "compatibiliyTuningPartId" });

            migrationBuilder.CreateIndex(
                name: "IX_Models_compatibiliyModelId_compatibiliyTuningPartId",
                table: "Models",
                columns: new[] { "compatibiliyModelId", "compatibiliyTuningPartId" });

            migrationBuilder.CreateIndex(
                name: "IX_ModelTuningPart_TuningPartId",
                table: "ModelTuningPart",
                column: "TuningPartId");

            migrationBuilder.AddForeignKey(
                name: "FK_Models_compatibiliy_compatibiliyModelId_compatibiliyTuningPartId",
                table: "Models",
                columns: new[] { "compatibiliyModelId", "compatibiliyTuningPartId" },
                principalTable: "compatibiliy",
                principalColumns: new[] { "ModelId", "TuningPartId" },
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TuningPart_compatibiliy_compatibiliyModelId_compatibiliyTuningPartId",
                table: "TuningPart",
                columns: new[] { "compatibiliyModelId", "compatibiliyTuningPartId" },
                principalTable: "compatibiliy",
                principalColumns: new[] { "ModelId", "TuningPartId" },
                onDelete: ReferentialAction.Restrict);
        }
    }
}

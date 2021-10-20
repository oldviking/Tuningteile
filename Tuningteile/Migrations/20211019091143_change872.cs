using Microsoft.EntityFrameworkCore.Migrations;

namespace Tuningteile.Migrations
{
    public partial class change872 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_compatibiliy_Models_ModelId",
                table: "compatibiliy");

            migrationBuilder.DropForeignKey(
                name: "FK_compatibiliy_TuningPart_TuningPartId",
                table: "compatibiliy");

            migrationBuilder.DropIndex(
                name: "IX_compatibiliy_TuningPartId",
                table: "compatibiliy");

            migrationBuilder.AddColumn<int>(
                name: "compatibiliyModelId",
                table: "TuningPart",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "compatibiliyTuningPartId",
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

            migrationBuilder.CreateIndex(
                name: "IX_TuningPart_compatibiliyModelId_compatibiliyTuningPartId",
                table: "TuningPart",
                columns: new[] { "compatibiliyModelId", "compatibiliyTuningPartId" });

            migrationBuilder.CreateIndex(
                name: "IX_Models_compatibiliyModelId_compatibiliyTuningPartId",
                table: "Models",
                columns: new[] { "compatibiliyModelId", "compatibiliyTuningPartId" });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Models_compatibiliy_compatibiliyModelId_compatibiliyTuningPartId",
                table: "Models");

            migrationBuilder.DropForeignKey(
                name: "FK_TuningPart_compatibiliy_compatibiliyModelId_compatibiliyTuningPartId",
                table: "TuningPart");

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
                name: "compatibiliyTuningPartId",
                table: "TuningPart");

            migrationBuilder.DropColumn(
                name: "compatibiliyModelId",
                table: "Models");

            migrationBuilder.DropColumn(
                name: "compatibiliyTuningPartId",
                table: "Models");

            migrationBuilder.CreateIndex(
                name: "IX_compatibiliy_TuningPartId",
                table: "compatibiliy",
                column: "TuningPartId");

            migrationBuilder.AddForeignKey(
                name: "FK_compatibiliy_Models_ModelId",
                table: "compatibiliy",
                column: "ModelId",
                principalTable: "Models",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_compatibiliy_TuningPart_TuningPartId",
                table: "compatibiliy",
                column: "TuningPartId",
                principalTable: "TuningPart",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

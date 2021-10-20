using Microsoft.EntityFrameworkCore.Migrations;

namespace Tuningteile.Migrations
{
    public partial class decimal_precision2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Model_manufacturer_ManufacturerId",
                table: "Model");

            migrationBuilder.DropForeignKey(
                name: "FK_ModelTuningPart_Model_ModelId",
                table: "ModelTuningPart");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Model",
                table: "Model");

            migrationBuilder.RenameTable(
                name: "Model",
                newName: "Models");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Models",
                newName: "Title");

            migrationBuilder.RenameIndex(
                name: "IX_Model_ManufacturerId",
                table: "Models",
                newName: "IX_Models_ManufacturerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Models",
                table: "Models",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Models_manufacturer_ManufacturerId",
                table: "Models",
                column: "ManufacturerId",
                principalTable: "manufacturer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ModelTuningPart_Models_ModelId",
                table: "ModelTuningPart",
                column: "ModelId",
                principalTable: "Models",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Models_manufacturer_ManufacturerId",
                table: "Models");

            migrationBuilder.DropForeignKey(
                name: "FK_ModelTuningPart_Models_ModelId",
                table: "ModelTuningPart");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Models",
                table: "Models");

            migrationBuilder.RenameTable(
                name: "Models",
                newName: "Model");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Model",
                newName: "Name");

            migrationBuilder.RenameIndex(
                name: "IX_Models_ManufacturerId",
                table: "Model",
                newName: "IX_Model_ManufacturerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Model",
                table: "Model",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Model_manufacturer_ManufacturerId",
                table: "Model",
                column: "ManufacturerId",
                principalTable: "manufacturer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ModelTuningPart_Model_ModelId",
                table: "ModelTuningPart",
                column: "ModelId",
                principalTable: "Model",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

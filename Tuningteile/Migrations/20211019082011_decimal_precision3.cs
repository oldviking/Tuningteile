﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace Tuningteile.Migrations
{
    public partial class decimal_precision3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "TuningPart",
                type: "decimal(8,0)",
                precision: 8,
                scale: 0,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(34,2)",
                oldPrecision: 34,
                oldScale: 2);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "TuningPart",
                type: "decimal(34,2)",
                precision: 34,
                scale: 2,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(8,0)",
                oldPrecision: 8,
                oldScale: 0);
        }
    }
}

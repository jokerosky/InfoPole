using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace InfoPole.Migrations
{
    public partial class DataFile : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Uploaded",
                table: "DataFiles",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<long>(
                name: "RecordsCount",
                table: "DataFiles",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<TimeSpan>(
                name: "ProcessingDuration",
                table: "DataFiles",
                nullable: true,
                oldClrType: typeof(TimeSpan));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Uploaded",
                table: "DataFiles",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "RecordsCount",
                table: "DataFiles",
                nullable: false,
                oldClrType: typeof(long));

            migrationBuilder.AlterColumn<TimeSpan>(
                name: "ProcessingDuration",
                table: "DataFiles",
                nullable: false,
                oldClrType: typeof(TimeSpan),
                oldNullable: true);
        }
    }
}

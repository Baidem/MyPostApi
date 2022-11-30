using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repositories.Migrations
{
    /// <inheritdoc />
    public partial class EntityPostNullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Content",
                table: "Posts",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 11, 30, 13, 0, 38, 627, DateTimeKind.Local).AddTicks(8759));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2022, 11, 30, 13, 0, 38, 627, DateTimeKind.Local).AddTicks(8762));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2022, 11, 30, 13, 0, 38, 627, DateTimeKind.Local).AddTicks(8764));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2022, 11, 30, 13, 0, 38, 627, DateTimeKind.Local).AddTicks(8765));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 11, 30, 13, 0, 38, 627, DateTimeKind.Local).AddTicks(8709));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2022, 11, 30, 13, 0, 38, 627, DateTimeKind.Local).AddTicks(8752));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2022, 11, 30, 13, 0, 38, 627, DateTimeKind.Local).AddTicks(8754));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2022, 11, 30, 13, 0, 38, 627, DateTimeKind.Local).AddTicks(8756));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Content",
                table: "Posts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 11, 30, 9, 18, 0, 767, DateTimeKind.Local).AddTicks(8353));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2022, 11, 30, 9, 18, 0, 767, DateTimeKind.Local).AddTicks(8355));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2022, 11, 30, 9, 18, 0, 767, DateTimeKind.Local).AddTicks(8358));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2022, 11, 30, 9, 18, 0, 767, DateTimeKind.Local).AddTicks(8360));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 11, 30, 9, 18, 0, 767, DateTimeKind.Local).AddTicks(8263));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2022, 11, 30, 9, 18, 0, 767, DateTimeKind.Local).AddTicks(8307));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2022, 11, 30, 9, 18, 0, 767, DateTimeKind.Local).AddTicks(8310));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2022, 11, 30, 9, 18, 0, 767, DateTimeKind.Local).AddTicks(8349));
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Repositories.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Theme = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AuthorId = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EditedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Posts_Users_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EditedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AuthorId = table.Column<int>(type: "int", nullable: true),
                    Content = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    PostId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Comments_Users_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "FirstName", "LastName", "Password" },
                values: new object[,]
                {
                    { 1, "Jerry.Seinfeld@aol.com", "Jerry", "Seinfeld", "password" },
                    { 2, "George.Costanza@aol.com", "George", "Costanza", "george" },
                    { 3, "Elaine.Benes@aol.com", "Elaine", "Benes", "jerry" },
                    { 4, "Cosmo.Kramer@aol.com", "Cosmo", "Kramer", "qzerty" }
                });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "Content", "CreatedDate", "EditedDate", "Image", "Theme", "Title", "AuthorId" },
                values: new object[,]
                {
                    { 1, "Toute l'histoire des tables à café ...", new DateTime(2022, 12, 1, 14, 22, 59, 946, DateTimeKind.Local).AddTicks(1975), null, null, "CULTURE", "Les tables à café", 4 },
                    { 2, "Comment trouver de nouveaux meilleurs amis ...", new DateTime(2022, 12, 1, 14, 22, 59, 946, DateTimeKind.Local).AddTicks(2114), null, null, "SOCIAL", "Les bons amis", 3 },
                    { 3, "Comment gérer le bus des Yankees ...", new DateTime(2022, 12, 1, 14, 22, 59, 946, DateTimeKind.Local).AddTicks(2117), null, null, "SPORT", "Yankee's Stadium", 2 },
                    { 4, "Les comédies club de NY ...", new DateTime(2022, 12, 1, 14, 22, 59, 946, DateTimeKind.Local).AddTicks(2119), null, null, "CULTURE", "Les comédies club", 1 }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "Content", "CreatedDate", "EditedDate", "PostId", "AuthorId" },
                values: new object[,]
                {
                    { 1, "Comment 1 ...", new DateTime(2022, 12, 1, 14, 22, 59, 946, DateTimeKind.Local).AddTicks(2122), null, 3, 2 },
                    { 2, "Comment 2 ...", new DateTime(2022, 12, 1, 14, 22, 59, 946, DateTimeKind.Local).AddTicks(2125), null, 4, 3 },
                    { 3, "Comment 3 ...", new DateTime(2022, 12, 1, 14, 22, 59, 946, DateTimeKind.Local).AddTicks(2127), null, 2, 1 },
                    { 4, "Comment 4 ...", new DateTime(2022, 12, 1, 14, 22, 59, 946, DateTimeKind.Local).AddTicks(2129), null, 1, 4 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comments_AuthorId",
                table: "Comments",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_PostId",
                table: "Comments",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_AuthorId",
                table: "Posts",
                column: "AuthorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
